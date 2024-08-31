document.addEventListener('DOMContentLoaded', function () {
    var maxPriceInput = document.getElementById('max-price');

    var priceLabel = document.getElementById('price-label');

    maxPriceInput.addEventListener('input', function () {
        priceLabel.textContent = '€' + maxPriceInput.value;
    });

    priceLabel.textContent ='€'+ maxPriceInput.value;
});

//function submitSearchForm() {
//    // Capture selected values before submitting the form
//    var category = $("#category").val();
//    var year = $("#year").val();
//    var engine = $("#engine").val();
//    var maxPrice = $("#max-price").val();

//    $.ajax({
//        type: "POST",
//        url: "@Url.Page("Search")",
//        data: $("#searchForm").serialize(),
//        success: function (response) {
//            // Update the vehicle list
//            $("#vehicleList").html($(response).find("#vehicleList").html());

//            // Set selected values back to combo boxes
//            $("#category").val(category);
//            $("#year").val(year);
//            $("#engine").val(engine);
//            $("#max-price").val(maxPrice);
//        }
//    });
//}
//function submitSearchForm() {
//    // Capture selected values before submitting the form
//    var category = $("#category").val();
//    var year = $("#year").val();
//    var engine = $("#engine").val();
//    var maxPrice = $("#max-price").val();

//    $.ajax({
//        type: "POST",
//        url: "@Url.Page("Search")",
//        data: $("#searchForm").serialize(),
//        success: function (response) {
//            // Update the vehicle list
//            $("#vehicleList").html($(response).find("#vehicleList").html());
//        }
//    });
//}

//document.addEventListener('DOMContentLoaded', function () {
//    var category = "@Model.category";
//    if (category !== "") {
//        var selectedOption = document.getElementById(category.toLowerCase() + "Option");
//        if (selectedOption) {
//            selectedOption.selected = true;
//        }
//    }
//});