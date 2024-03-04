function circleCompute(radius){
    if (isNumber(radius)){
        computeDiameter(radius);
        computeArea(radius);
        computeCircumference(radius);
        document.getElementById("error").style.display = "none";
        document.getElementById("results").style.display = "block";
    } else {
        document.getElementById("results").style.display = "none";
        document.getElementById("error").style.display = "block";
    }
}

function isNumber(radius){
    return !isNaN(parseFloat(radius)) && isFinite(radius);
}

function computeDiameter(radius){
    var diameter = radius * 2;
    diameter = (parseFloat(diameter).toPrecision(12));
    diameter = parseFloat(diameter).toString();
    document.getElementById("diameterDisplay").textContent = diameter;
}

function computeArea(radius){
    var area = Math.PI * radius * radius;
    area = (parseFloat(area).toPrecision(12));
    area = parseFloat(area).toString();
    document.getElementById("areaDisplay").textContent = area;
}

function computeCircumference(radius){
    var circumference = 2 * Math.PI * radius;
    circumference = (parseFloat(circumference).toPrecision(12));
    circumference = parseFloat(circumference).toString();
    document.getElementById("circumferenceDisplay").textContent = circumference;
}

function handleKeyPress(event) {
    if (event.key === "Enter") {
        circleCompute(document.getElementById('radiusInput').value);
    }
}