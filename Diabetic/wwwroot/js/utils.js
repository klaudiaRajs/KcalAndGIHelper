function getKcalsForAmount(amount, kcalPer100g)
{
    return Math.round((amount / 100) * kcalPer100g); 
}

function getGlycemicIndexForAmount(amount, productGI, carbsPer100g)
{
    return Math.floor((productGI * (carbsPer100g * (amount / 100))) / 100);
}