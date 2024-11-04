'use strict'

const $navbar = document.querySelector("[data-navbar]")
const $navToggle = document.querySelector("[data-nav-toggler]")

$navToggle.addEventListener("click", () => $navbar.classList.toggle("active"))

const $header = document.querySelector("[data-header]")

window.addEventListener("scroll", () => {
    $header.classList[window.scrollY > 50 ? "add" : "remove"]("active")
})

/***
 * Add to favourite button toggle
 */

const $toggleBtns = document.querySelectorAll("[data-toggle-btn]")

$toggleBtns.forEach(toggleBtn => {
    toggleBtn.addEventListener("click", (e) => {
        e.currentTarget.classList.toggle("active")
    })
})