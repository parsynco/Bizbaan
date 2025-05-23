﻿/* 
Tool Cool Range Slider - Moving Tooltip Plugin v1.0.6
https://github.com/mzusin/toolcool-range-slider 
MIT License        
Copyright (c) 2022-present, Miriam Zusin                         
*/
(() => {
    var _ = o => !isNaN(parseFloat(o)) && isFinite(o), a = (o, n) => _(o) ? Number(o) : n; var A = o => o == null ? !1 : typeof o == "boolean" ? o : o.trim().toLowerCase() === "true"; window.tcRangeSliderPlugins = window.tcRangeSliderPlugins || []; var S = 40, U = 35, O = 30, q = "#475569", X = "#fff", j = 20, w = () => {
        let o = null, n = null, T = !1, c = S, v = U, h = O, I = q, P = X, b = "", E = "", L, f = [], r = null, y = null, Z = () => { r == null || r.classList.toggle("is-after", c <= 0) }, J = () => { var e; let t = (e = o == null ? void 0 : o.shadowRoot) == null ? void 0 : e.querySelector("#range-slider"); r = document.createElement("div"), r.classList.add("tooltips"), t.prepend(r), Z() }, H = t => { let e = document.createElement("div"); return e.style.zIndex = j.toString(), e.className = t, e }, D = (t, e, u, s, d) => { !t || (e === "vertical" ? (t.style.left = `${-c}px`, t.style.top = s != null ? s : "0") : (t.style.left = u != null ? u : "0", t.style.top = `${-c}px`), t.style.width = `${v}rem`, t.style.height = `${h}rem`, t.style.background = I, t.style.color = P, t.style.zIndex = d.toString()) }, z = t => { let e = t; return typeof L == "function" && (e = L(t)), E === "prefix" ? `${b}${e}` : `${e}${b}` }, p = () => { var s, d, i, g; let t = (s = n == null ? void 0 : n.getValues()) != null ? s : [], e = (d = n == null ? void 0 : n.getPointerElements()) != null ? d : [], u = (i = n == null ? void 0 : n.getType()) != null ? i : "horizontal"; if (!!t) for (let l = 0; l < t.length; l++) { let x = f[l]; if (!x) continue; let m = ((g = t[l]) != null ? g : "").toString(); x.textContent = z(m), D(x, u, e[l].style.left, e[l].style.top, e[l].style.zIndex) } }, K = () => { var e; let t = (e = n == null ? void 0 : n.getValues()) != null ? e : []; if (!!t) { for (let u = 0; u < t.length; u++) { let s = H(`tooltip tooltip-${u + 1}`); s.style.position = "absolute", f.push(s), r == null || r.prepend(s) } p() } }, Q = () => { !o || (y = new ResizeObserver(t => { for (let e of t) p() }), y.observe(o)) }, C = t => { T = t, T ? (J(), K(), Q()) : N() }, M = t => { c = t, p() }, F = t => { v = t, p() }, B = t => { h = t, p() }, R = t => { I = t, p() }, k = t => { P = t, p() }, G = t => { b = t, p() }, W = t => { E = t, p() }, Y = t => { L = t, p() }, V = t => { var s, d; if (!T || !t.values) return; let e = (s = n == null ? void 0 : n.getPointerElements()) != null ? s : [], u = (d = n == null ? void 0 : n.getType()) != null ? d : "horizontal"; for (let i = 0; i < t.values.length; i++) { let g = t.values[i], l = f[i]; if (g === void 0 && !!l) { l.remove(), f[i] = void 0; continue } if (g !== void 0 && !l) { let m = H(`tooltip tooltip-${i + 1}`), $ = (g != null ? g : "").toString(); m.textContent = z($), m.style.position = "absolute", D(m, u, e[i].style.left, e[i].style.top, e[i].style.zIndex), f[i] = m, r == null || r.append(m) } if (!l) continue; let x = (g != null ? g : "").toString(); l.textContent = z(x), D(l, u, e[i].style.left, e[i].style.top, e[i].style.zIndex) } }, N = () => { r == null || r.remove(); for (let t of f) !t || t.remove(); f = [], y == null || y.disconnect() }; return {
            get name() { return "Moving Tooltip" }, init: (t, e, u, s) => { o = t, n = s, c = a(t.getAttribute("moving-tooltip-distance-to-pointer"), S), v = a(t.getAttribute("moving-tooltip-width"), U), h = a(t.getAttribute("moving-tooltip-height"), O), I = t.getAttribute("moving-tooltip-bg") || q, P = t.getAttribute("moving-tooltip-text-color") || X, b = t.getAttribute("moving-tooltip-units") || "", E = t.getAttribute("moving-tooltip-units-type") || "", C(A(t.getAttribute("moving-tooltip"))) }, update: V, onAttrChange: (t, e) => { t === "moving-tooltip" && C(A(e)), t === "moving-tooltip-distance-to-pointer" && M(a(e, S)), t === "moving-tooltip-width" && F(a(e, U)), t === "moving-tooltip-height" && B(a(e, O)), t === "moving-tooltip-bg" && R(e), t === "moving-tooltip-text-color" && k(e), t === "moving-tooltip-units" && G(e), t === "moving-tooltip-units-type" && W(e) }, gettersAndSetters: [{ name: "movingTooltip", attributes: { get() { return T != null ? T : !1 }, set: t => { C(A(t)) } } }, { name: "distanceToPointer", attributes: { get() { return c != null ? c : !1 }, set: t => { M(a(t, S)) } } }, { name: "tooltipWidth", attributes: { get() { return v }, set: t => { F(a(t, U)) } } }, { name: "tooltipHeight", attributes: { get() { return h }, set: t => { B(a(t, O)) } } }, { name: "tooltipBg", attributes: { get() { return I }, set: t => { R(t) } } }, { name: "tooltipTextColor", attributes: { get() { return P }, set: t => { k(t) } } }, { name: "tooltipUnits", attributes: { get() { return b }, set: t => { G(t) } } }, { name: "tooltipUnitType", attributes: { get() { return E }, set: t => { W(t) } } }, { name: "formatTooltipValue", attributes: { get() { return L }, set: t => { Y(t) } } }], css: `
.tooltip{
  background: #475569;
  color: #fff;
  font-size: 0.8rem;
  border-radius: 3px;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  transform: translate(-50%, -50%);
  pointer-events: none;
  z-index: ${j};
}  

.tooltip::after {
    content: '';
    position: absolute;
    width: 7px;
    height: 6px;
    transform: translate(0%, -50%) rotate(45deg);
    background-color: inherit;
    z-index: -1;
    top: 100%;
}

.is-after .tooltip::after {
  top: 0;
}

.type-vertical .tooltip::after{
  transform: translate(-50%, 0%) rotate(45deg);
  left: 100%;
  top: auto;
}

.type-vertical .is-after .tooltip::after{
  left: 0%;
}

.animate-on-click .tooltip{
    transition: all var(--animate-onclick);
}
    `, destroy: N
        }
    }; window.tcRangeSliderPlugins.push(w); var it = w;
})();