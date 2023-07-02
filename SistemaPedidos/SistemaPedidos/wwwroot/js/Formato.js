 function formato() {
    var numeroDecimal = document.getElementById("PrecioProd").value;
    var numeroDecimalComa = numeroDecimal.replace(".", ",");
    document.getElementById("PrecioProd").value = numeroDecimalComa;
}