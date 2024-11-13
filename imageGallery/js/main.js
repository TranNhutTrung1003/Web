var images = document.querySelectorAll('.image');
var galleryImg = document.querySelector('.gallery__inner img');
var gallery = document.querySelector('.gallery');
var btnPrev = document.querySelector('.left');
var btnNext = document.querySelector('.right');
var btnClose = document.querySelector('.btnClose');

var currentIndex = 0;
var img = [
    "./images/img1.jpeg", 
    "./images/img2.jpeg",
    "./images/img3.jpeg",
    "./images/img4.jpeg",
    "./images/img5.jpeg",
    "./images/img6.jpeg",
    "./images/img7.jpeg",
    "./images/img8.jpeg",
]

images.forEach((img, index) => {
    img.addEventListener('click', (e) => {
        currentIndex = index;
        gallery.classList.add('show');
        galleryImg.src = e.target.src;
    })
})

btnClose.addEventListener('click', () => {
    gallery.classList.remove('show');
})

btnPrev.addEventListener('click', (e) => {
    if(currentIndex == 0) currentIndex = img.length - 1;
    else currentIndex = currentIndex - 1;

    galleryImg.src = img[currentIndex];
})

btnNext.addEventListener('click', (e) => {
    if(currentIndex == img.length - 1) currentIndex = 0;
    else currentIndex = currentIndex + 1;

    galleryImg.src = img[currentIndex];
})