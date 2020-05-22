$(document).ready(function () {
    $(".answerVisibility").hide();
});

function showAnswer() {
    if (document.getElementById("btnShowAnswers").innerHTML == "Show All Answers") {
        document.getElementById("btnShowAnswers").innerHTML = "Hide All Answers";
        $(".answerVisibility").show();
    } else {
        document.getElementById("btnShowAnswers").innerHTML = "Show All Answers";
        $(".answerVisibility").hide();
    }
}