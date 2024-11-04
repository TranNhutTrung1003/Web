var songs = [
    {name: "Legion", imageLogo: "1.jpg", filePath: "1.mp3"},
    {name:"Trap", imageLogo: "2.jpg", filePath: "2.mp3"},
    {name:"They man", imageLogo: "3.jpg", filePath: "3.mp3"},
    {name:"Plug walk", imageLogo: "4.jpg", filePath: "4.mp3"},
    {name:"Artist name", imageLogo: "5.jpg", filePath: "5.mp3"},
    {name:"Safety dance", imageLogo: "6.jpg", filePath: "6.mp3"},
    {name:"Back-it up", imageLogo: "7.jpg", filePath: "7.mp3"},
    {name:"First song", imageLogo: "8.jpg", filePath: "8.mp3"},
    {name:"Second song", imageLogo: "9.jpg", filePath: "9.mp3"}
]

let songUpdateInterval;
let songIndex = 0
let currentAudio = new Audio("./songs/1.mp3")

var listSong = document.querySelector(".song-list")
var inputElement = document.querySelector("#myProgressBar")
var buttonStop = document.querySelector(".stop")
var buttonBackward = document.querySelector(".backward")
var buttonForward = document.querySelector(".forward")
var songInfo = document.querySelector(".song-info")

function formTime(seconds){
    let minutes = Math.floor(seconds / 60);
    let secondsRemaining = Math.floor(seconds % 60);
    if (secondsRemaining < 10) {
        secondsRemaining = '0' + secondsRemaining;
    }
    return minutes + ':' + secondsRemaining;
}

function changeSong(index){
    songIndex = index

    currentAudio.currentTime = 0;
    currentAudio.src = `./songs/${songs[songIndex].filePath}`;
    songInfo.innerHTML = `
        <img src="./Images/playing.gif" width="42" alt="" id="gif">
        ${songs[songIndex].name}
    `

    buttonStop.classList.remove("fa-stop")
    buttonStop.classList.remove("fa-play")
    buttonStop.classList.add("fa-stop")

    document.getElementById("gif").style.opacity = 1

    currentAudio.play();
    runSong()
}

function runSong(){
    if (songUpdateInterval) {
        clearInterval(songUpdateInterval);
    }

    songUpdateInterval = setInterval(() => {
        if (currentAudio.paused || currentAudio.ended) {
            clearInterval(songUpdateInterval);

            document.getElementById("gif").style.opacity = 0

            buttonStop.classList.remove("fa-stop")
            buttonStop.classList.remove("fa-play")
            buttonStop.classList.add("fa-play")
        } else {
            inputElement.value = (currentAudio.currentTime / currentAudio.duration) * 100;
        }
    }, 100);
}

function startApp(){
    return Promise.all(songs.map((song, index) => {
        return new Promise((resolve) => {
            let fileSong = `./songs/${song.filePath}`;
            let audioSong = new Audio(fileSong);

            audioSong.addEventListener('loadedmetadata', function() {
                let listItem = `
                    <li class="item-song col-sm-10 col-md-6 col-lg-4" onclick="changeSong(${index})">
                        <img class="song-logo" src="./covers/${song.imageLogo}" alt="logo bài hát" width="30">
                        <span class="song-name">${song.name}</span>
                        <span class="song-length">
                            ${formTime(parseFloat(audioSong.duration))}
                            <i class="fa-solid fa-play-circle"></i>
                        </span>
                    </li>
                `;
                resolve(listItem);
            });
        });
    })).then(items => {
        listSong.innerHTML = items.join('');
    });
}

buttonStop.addEventListener("click", (e) => {
    if(currentAudio.paused || currentAudio.duration <= 0){
        currentAudio.play()
        runSong()
        document.getElementById("gif").style.opacity = 1
    } else {
        currentAudio.pause()
        document.getElementById("gif").style.opacity = 0
    }
    e.currentTarget.classList.toggle("fa-stop")
    e.currentTarget.classList.toggle("fa-play")
})

buttonForward.addEventListener("click", (e) => {
    if(currentAudio.currentTime + 10 >= currentAudio.duration){
        currentAudio.currentTime = currentAudio.duration

        buttonStop.classList.remove("fa-stop")
        buttonStop.classList.remove("fa-play")
        buttonStop.classList.add("fa-play")

        inputElement.value = 100

        currentAudio.pause()
    } else {
        currentAudio.currentTime += 10
        inputElement.value = (currentAudio.currentTime / currentAudio.duration) * 100;
    }
})

buttonBackward.addEventListener("click", (e) => {
    if(currentAudio.currentTime - 10 <= 0){
        currentAudio.currentTime = 0
        inputElement.value = 0
    } else {
        currentAudio.currentTime -= 10
        inputElement.value = (currentAudio.currentTime / currentAudio.duration) * 100;
    }
})

inputElement.addEventListener("input", (e) => {
    if (e.target.value == 100) {
        currentAudio.currentTime = currentAudio.duration;
        currentAudio.pause();

        document.getElementById("gif").style.opacity = 0

        buttonStop.classList.remove("fa-stop")
        buttonStop.classList.remove("fa-play")
        buttonStop.classList.add("fa-play")
    } else {
        currentAudio.currentTime = currentAudio.duration * (e.target.value / 100);
    }
});

function init(){
    listSong.innerHTML = startApp()
}

init()

