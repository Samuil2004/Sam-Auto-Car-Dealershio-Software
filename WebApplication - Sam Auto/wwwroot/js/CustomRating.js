//function changeRating(rating) {
//    var buttons = document.getElementsByClassName("rateBtn");
//    for (var i = 0; i < rating; i++) {
//        buttons[i].getElementsByTagName("img")[0].src ="~/images/Full star.png";
//    }
//}

//function changeRating(rating) {
//    var buttons = document.getElementsByClassName("rateBtn");
//    for (var i = 0; i < buttons.length; i++) {
//        var img = buttons[i].getElementsByTagName("img")[0];
//        if (i < rating) {
//            img.src = "~/images/Full star.png";
//        } else {
//            img.src = "~/images/Empty star.png";
//        }
//    }
//}

//document.addEventListener("DOMContentLoaded", function () {
//    const buttons = document.querySelectorAll(".rateBtn");

//    buttons.forEach((button, index) => {
//        button.addEventListener("mouseover", () => {
//            for (let i = 0; i <= index; i++) {
//                const img = buttons[i].querySelector(".image");
//                img.src = '/images/FullStar.png';
//            }
//            for (let i = index + 1; i < buttons.length; i++) {
//                const img = buttons[i].querySelector(".image");
//                img.src = '/images/EmptyStar.png';
//            }
//        });
//        button.addEventListener("mouseout", () => {
//            buttons.forEach(btn => {
//                const img = btn.querySelector(".image");
//                img.src = '/images/EmptyStar.png';
//            });
//        });
//    });
//});

document.addEventListener("DOMContentLoaded", function () {
    const buttons = document.querySelectorAll(".rateBtn");

    buttons.forEach((button, index) => {
        button.addEventListener("mouseover", () => {
            for (let i = 0; i <= index; i++) {
                const img = buttons[i].querySelector(".image");
                img.src = '/images/FullStar.png';
            }
            for (let i = index + 1; i < buttons.length; i++) {
                const img = buttons[i].querySelector(".image");
                img.src = '/images/EmptyStar.png';
            }
        });
        button.addEventListener("mouseout", () => {
            buttons.forEach(btn => {
                const img = btn.querySelector(".image");
                img.src = '/images/EmptyStar.png';
            });
        });
    });
});
