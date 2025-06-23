// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

import Trix from "./trix.esm.min.js";

document.addEventListener("trix-before-initialize", (_) => {
    Trix.config.blockAttributes.heading1 = {
        tagName:       "h2",
        parse:         el => el.tagName === "H2",
        breakOnReturn: true,
        terminal:      true,
        group:         false
    };
})
