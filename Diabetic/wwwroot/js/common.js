function setTotalGlBackground(elementIdToSetColorTo, elementValue) {
    const totalRecipeGL = $(elementIdToSetColorTo)[0];
    if (elementValue <= 79) {
        $(elementIdToSetColorTo)[0].style.backgroundColor = "green";
    } else if (elementValue <= 119) {
        $(elementIdToSetColorTo)[0].style.backgroundColor = "orange";
    } else {
        $(elementIdToSetColorTo)[0].style.backgroundColor = "red";
    }
}