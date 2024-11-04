const gameContainer = document.querySelector(".container"),
userResult = document.querySelector(".user_result img"),
cpuResult = document.querySelector(".cpu_result img"),
result = document.querySelector(".result_title"),
optionImage = document.querySelectorAll(".option_image");

var value = ["B", "P", "K"];

optionImage.forEach((Image, index) => {
  Image.addEventListener("click", (e) => {
    Image.classList.add("active");

    // xóa các lựa chọn khác khi chọn một lựa chọn kéo, búa và bao
    optionImage.forEach((Image2, index2) => {
      index != index2 && Image2.classList.remove("active");
    })

    // hiện thị đáp án người dùng lựa chọn
    let imageSrc = e.target.src;
    userResult.src = imageSrc;
    
    // xử lý và hiện thị đáp án của máy
    let indexCPU = Math.floor(Math.random() * 3);
    cpuResult.src = optionImage[indexCPU].querySelector("img").src;

    // so sánh đáp án và hiện thị kết quả
    let cpuValue = value[indexCPU];
    let userValue = value[index];

    let outcomes = {
      BP: "user",
      BB: "Draw",
      BK: "cpu",
      PB: "cpu",
      PP: "Draw",
      PK: "user",
      KB: "user",
      KP: "cpu",
      KK: "Draw"
    };

    let matchResult = outcomes[userValue + cpuValue];
    result.textContent = userValue === cpuValue ? "Match Draw" : `${matchResult} won`;
  })
})

