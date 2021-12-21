let destino = document.getElementById("destino");
let pEl = document.createElement("p");
let precoEl = document.getElementById("preco");
let valEl = document.getElementById("val");

precoEl.appendChild(pEl);
function selecionar() {
  let valor;
  if (destino.value == "Bahamas") {
    valor = "R$ 4339.90";
  } else if (destino.value == "2") {
    valor = "R$ 5339.90";
  } else if (destino.value == "3") {
    valor = "R$ 4499.90";
  } else if (destino.value == "4") {
    valor = "R$ 2190.95";
  } else if (destino.value == "5") {
    valor = "R$ 4400.00";
  } else if (destino.value == "6") {
    valor = "R$ 3499.90";
  } else {
    valor = "";
  }

  valEl.value = valor.slice(3);
  pEl.innerHTML = valor;
}
