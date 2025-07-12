function updateTotal(element, kcalElement, glElement, kcalPer100g, productGI, carbsPer100g, categoryId, productName) {
    let amount = element.value;
    let kcals = getKcalsForAmount(amount, kcalPer100g);
    let gl = getGlycemicIndexForAmount(amount, productGI, carbsPer100g);
    kcalElement.innerHTML = kcals;
    glElement.innerHTML = gl;
    addItemToSummaryBelowGroup(categoryId, productName, kcals, amount, gl);
    setIndividualGlBackgrounds();
    setTotalGlBackground();
}

function addItemToSummaryBelowGroup(categoryId, productName, kcal, amount, gl) {
    let summary = document.getElementById("summary-" + categoryId);
    summary.innerHTML = summary.innerHTML + "<p>" + productName + ": " + amount + "gr (" + kcal + "kcal, GL: " + gl + ") </p>";
}

function toggleAmount(element) {
    if (element.style.display === "none") {
        element.style.display = "block";
    } else {
        element.style.display = "none";
    }
}

$(function () {
    setIndividualGlBackgrounds();
    setTotalGlBackground();
});

function setTotalGlBackground() {
    const totalRecipeGL = $("#totalRecipeGL")[0];
    if (totalRecipeGL.value <= 79) {
        $("#totalRecipeGL")[0].style.backgroundColor = "green";
    } else if (totalRecipeGL.value <= 119) {
        $("#totalRecipeGL")[0].style.backgroundColor = "orange";
    } else {
        $("#totalRecipeGL")[0].style.backgroundColor = "red";
    }
}

function setIndividualGlBackgrounds() {
    const items = $(".total-gl:visible");
    for (let i = 0; i < items.length; i++) {
        const item = parseFloat(items[i].value);
        if (item <= 10) {
            items[i].style.backgroundColor = "green";
        } else if (item <= 39) {
            items[i].style.backgroundColor = "orange";
        } else {
            items[i].style.backgroundColor = "red";
        }
    }
}

function updateTotals(data, categoryId) {
    document.getElementById('totalRecipe').value = data.totalKcal;
    document.getElementById('totalRecipeGL').value = data.totalGl;
    document.getElementById('totalRecipeKcalBox' + categoryId).innerHTML = data.totalKcal + " kcal";
    document.getElementById('totalRecipeGlBox' + categoryId).innerHTML = data.totalGl + " GL";
}

function addProductToRecipe(productId, recipeId, amountInputId, categoryId) {
    let amount = document.getElementById(amountInputId).value;

    const payload = {
        amount: amount,
        productId: productId,
        recipeId: recipeId
    };

    let data = JSON.stringify(payload);
    callRequest("/recipe/addProductToRecipe", data, categoryId);
}

function removeProductFromRecipe(productId, recipeId, categoryId, totalKcal, totalGl) {
    const payload = {
        recipeId: recipeId,
        productId: productId,
    };

    let data = JSON.stringify(payload);
    callRequest("/recipe/removeProductFromRecipe", data, categoryId);
    zeroOutInput(totalKcal, totalGl, productId);
    uncheckProductAndHideAmountBox(productId);
}

function uncheckProductAndHideAmountBox(productId) {
    toggleAmount(document.getElementById("amountBox" + productId));
    document.getElementById("checkBox" + productId).checked = false;
}

function zeroOutInput(totalKcal, totalGl, productId) {
    document.getElementById("amountInput" + productId).value = 0;
    totalKcal.innerHTML = 0;
    totalGl.innerHTML = 0;
}

function callRequest(url, data, categoryId) {
    fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: data
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                updateTotals(data, categoryId);
                if (data.recipeAdded) {
                    window.location.reload();
                }
            } else {
                console.error("Failed to remove product.");
            }
        })
        .catch(error => {
            console.error("Error:", error);
        });
}