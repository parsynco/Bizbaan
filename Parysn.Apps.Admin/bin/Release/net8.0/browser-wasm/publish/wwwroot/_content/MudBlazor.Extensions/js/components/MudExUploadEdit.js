﻿export function initializeMudExUploadEdit(dropZoneElement, inputFile, allowFolderUpload, dotnet) {
    // Add a class when the user drags a file over the drop zone
    function onDragHover(e) {
        e.preventDefault();
        dropZoneElement.classList.add("hover");
    }
    function onDragLeave(e) {
        e.preventDefault();
        dropZoneElement.classList.remove("hover");
    }
    async function readFolder(dirHandle, paths = [], initialFolder = '') {
        const results = [];
        for await (const [key, fileOrFolder] of dirHandle.entries()) {
            if (fileOrFolder.kind === 'directory') {
                const newPath = paths.concat(key);
                results.push(...(await readFolder(fileOrFolder, newPath, initialFolder)));
            }
            else {
                var file = await fileOrFolder.getFile();
                file.relativePath = initialFolder + paths.join('/') + (paths.length > 0 ? '/' : '') + key;
                results.push(file);
            }
        }
        return results;
    }


    function setFiles(files) {
        inputFile.files = Array.isArray(files) ? createFileListFromArray(files) : files;
        dotnet.invokeMethodAsync('UpdatePathMappings', Array.from(inputFile.files).map(f => {
            return {
                name: f.name,
                relativePath: f?.relativePath?.substring(0, f?.relativePath?.lastIndexOf('/') + 1),
                size: f.size,
                contentType: f.type
            }
        }));
        inputFile.dispatchEvent(new Event('change', { bubbles: true }));
    }
    async function openFolderPicker() {
        const dirHandle = await window.showDirectoryPicker();
        const files = await readFolder(dirHandle, [], `${dirHandle.name}/`);
        setFiles(files);
    }
    function createFileListFromArray(filesArray) {
        const container = new DataTransfer();
        (filesArray || []).forEach(f => container.items.add(f));
        return container.files;
    }
    function isFolder(fileTransferItem) {
        if (!fileTransferItem.type || fileTransferItem.type === "") {
            return fileTransferItem.webkitGetAsEntry().isDirectory;
        }
        return false;
    }
    async function readFromDataTransfer(args) {
        let files = [];
        for await (const item of args.dataTransfer ? args.dataTransfer.items : args) {
            if (isFolder(item)) {
                var handle = await item.getAsFileSystemHandle();
                files.push(...(await readFolder(handle, [], `${handle.name}/`)));
            }
            else {
                files.push(item.getAsFile());
            }
        }
        return files;
    }
    // Handle the paste and drop events
    async function onDrop(e) {
        e.preventDefault();
        e.stopPropagation();
        dropZoneElement.classList.remove("hover");
        if (allowFolderUpload) {
            setFiles(await readFromDataTransfer(e));
        }
        else {
            setFiles(e.dataTransfer.files);
        }
    }
    async function onPaste(e) {
        if (allowFolderUpload) {
            setFiles(await readFromDataTransfer(e.clipboardData.items));
        }
        else {
            setFiles(e.clipboardData.files);
        }
    }
    // Register all events
    if (dropZoneElement) {
        dropZoneElement.ondragenter = onDragHover;
        dropZoneElement.ondragover = onDragHover;
        dropZoneElement.ondragleave = onDragLeave;
        dropZoneElement.ondrop = onDrop;
        dropZoneElement.onpaste = onPaste;
    }
    
    // The returned object allows to unregister the events when the Blazor component is destroyed
    return {
        selectFolder: () => {
            openFolderPicker();
        },
        dispose: () => {
            if (dropZoneElement) {
                dropZoneElement.ondragenter = null;
                dropZoneElement.ondragover = null;
                dropZoneElement.ondragleave = null;
                dropZoneElement.ondrop = null;
                dropZoneElement.onpaste = null;
            }
        }
    };
}