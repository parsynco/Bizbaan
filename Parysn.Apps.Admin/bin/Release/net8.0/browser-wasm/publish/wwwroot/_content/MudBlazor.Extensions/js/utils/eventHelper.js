﻿class MudExEventHelper {
    static isWithin(event, element) {
        if (!element || !event) {
            return false;
        }
        let rect = element.getBoundingClientRect();
        return (event.clientX > rect.left &&
        event.clientX < rect.right &&
        event.clientY < rect.bottom &&
        event.clientY > rect.top);
    }

    static clickElementById(elementId) {
        var retries = 5;
        function tryClick() {
            var elem = document.querySelector('#' + elementId) || document.getElementById(elementId);
            if (elem) {
                elem.click();
            } else if (retries > 0) {
                retries--;
                setTimeout(tryClick, 100);  // try again after 100ms
            }
        }
        tryClick();
    }

    static stringifyEvent(e) {
        const obj = {};
        for (let k in e) {
            obj[k] = e[k];
        }
        return JSON.stringify(obj, (k, v) => {
            if (v instanceof Node)
                return 'Node';
            if (v instanceof Window)
                return 'Window';
            return v;
        }, ' ');
    }

    static cloneEvent(e, serializable) {
        if (serializable) {
            return JSON.parse(this.stringifyEvent(event));
        }
        if (e === undefined || e === null)
            return undefined;
        function ClonedEvent() { }
        ;
        let clone = new ClonedEvent();
        for (let p in e) {
            let d = Object.getOwnPropertyDescriptor(e, p);
            if (d && (d.get || d.set))
                Object.defineProperty(clone, p, d);
            else
                clone[p] = e[p];
        }
        Object.setPrototypeOf(clone, e);
        return clone;
    }
}

window.MudExEventHelper = MudExEventHelper;