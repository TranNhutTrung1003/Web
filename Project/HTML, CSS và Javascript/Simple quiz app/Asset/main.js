var $ = document.querySelector.bind(document);
var $$ = document.querySelectorAll.bind(document);

var quiz = [
    {
        question: "Which is largest animal in the world",
        answer: [
            {text: "shark", correct: false},
            {text: "blue whale", correct: true},
            {text: "Elephant", correct: false},
            {text: "Giraffe", correct: false}
        ]
    },
    {
        question: "Which is the smallest continent in the world",
        answer: [
            {text: "Asia", correct: false},
            {text: "Australia", correct: true},
            {text: "Arctic", correct: false},
            {text: "Africa", correct: false}
        ]
    },
    {
        question: "Which is the smallest continent in the world",
        answer: [
            {text: "Asia", correct: true},
            {text: "Australia", correct: false},
            {text: "Arctic", correct: false},
            {text: "Africa", correct: false}
        ]
    }
]

var listAnswer = $$(".app-item-answer");
var question = $(".app-question");
var btnNext = $(".btn-next");

var currentIndexAnswer = 0;

// Hàm reset lại class active
function resetResult(){
    listAnswer.forEach((itemAnswer) => {
        itemAnswer.dataset.correct = false;
        itemAnswer.style.backgroundColor = "";
    });
}

// Hàm thiết lập nội dung
function startQuiz(){
    var indexAnswer = 0;

    // Thiết lập lại trạng thái ban đầu
    resetResult();

    // Thiết lập nội dung câu hỏi
    question.innerText = `${currentIndexAnswer+1}. ${quiz[currentIndexAnswer].question}?`;

    // Thiết lập nội dung các câu trả lời
    listAnswer.forEach((itemAnswer) => {
        itemAnswer.innerText = quiz[currentIndexAnswer].answer[indexAnswer].text;
        itemAnswer.dataset.correct = quiz[currentIndexAnswer].answer[indexAnswer].correct; // Store correct answer
        indexAnswer += 1;
    });

    btnNext.classList.add("d-none");
}

// Hàm để chuyển đổi câu hỏi
btnNext.addEventListener("click", () => {
    currentIndexAnswer++;
    if (currentIndexAnswer < quiz.length) {
        startQuiz();
    } else {
        // Nếu không còn câu hỏi nào
        alert("Quiz completed!");
    }
});

// Thiết lập chọn đáp án đúng
listAnswer.forEach((itemAnswer) => {
    itemAnswer.addEventListener("click", (event) => {
        var selectedAnswer = event.currentTarget;
        var correct = selectedAnswer.dataset.correct === "true";

        if (correct) {
            selectedAnswer.style.backgroundColor = "green";
        } else {
            selectedAnswer.style.backgroundColor = "red";
            listAnswer.forEach((item) => {
                if (item.dataset.correct === "true") {
                    item.style.backgroundColor = "green";
                }
            });
        }
        btnNext.classList.remove("d-none");
    });
});

(() => {
    startQuiz();
})();
