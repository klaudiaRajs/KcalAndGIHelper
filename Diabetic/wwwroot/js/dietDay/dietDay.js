function updateTotal(recipeId, meal, url) {
    $.ajax({
        url: url,
        type: 'GET',
        data: {
            recipeId: recipeId
        },
        success: function (res) {
            var idKcals = "#" + meal + "Kcals";
            var idGls = "#" + meal + "GLs";
            $(idKcals)[0].value = res.kcals
            $(idGls)[0].value = res.gl
            updateSum(".kcals", "#totalKcals", " kcal, ");
            updateSum(".gls", "#totalGLs");

        }
    });
}

function updateSum(fieldToUpdate, result, restOfText) {
    var items = $(fieldToUpdate);
    var total = 0;
    for (var i = 0; i < items.length; i++) {
        var kcal = parseInt(items[i].value);
        var isANumber = isNaN(kcal) === false;
        if (kcal != 0 && isANumber) {
            total += kcal;
        }
    }
    ($(result)[0]).innerHTML = total + (restOfText ? restOfText : "");
    setTotalGlBackground("#totalGLs", total);
}