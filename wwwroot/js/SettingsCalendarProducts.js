// Obtener la fecha actual
var fechaActual = new Date();
// Agregar exactamente 7 d�as a la fecha actual
fechaActual.setDate(fechaActual.getDate() + 7);
// Convertir la fecha a formato YYYY-MM-DD
var fechaMinima = fechaActual.toISOString().split('T')[0];
// Establecer la fecha m�nima del campo de entrada
document.getElementById("ExpirationDate").setAttribute("min", fechaMinima);