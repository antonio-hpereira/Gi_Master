function validarCPF(cpf) {
	let meuCampo = document.getElementById('CPF');
	let error = meuCampo.style.border = '2px solid #e63636'
	//let error = span.style.display = 'block'
	//let error = meuCampo.ariaInvalid = false
	//let ok = meuCampo.style.border = ""
	//cpf = cpf.replace(/[^\d]+/g, '');
	if (cpf == '') return false;
	// Elimina CPFs invalidos conhecidos	
	if (cpf.length != 11 ||
		cpf == "00000000000" ||
		cpf == "11111111111" ||
		cpf == "22222222222" ||
		cpf == "33333333333" ||
		cpf == "44444444444" ||
		cpf == "55555555555" ||
		cpf == "66666666666" ||
		cpf == "77777777777" ||
		cpf == "88888888888" ||
		cpf == "99999999999")
		return error;
	// Valida 1o digito	
	add = 0;
	for (i = 0; i < 9; i++)
		add += parseInt(cpf.charAt(i)) * (10 - i);
	rev = 11 - (add % 11);
	if (rev == 10 || rev == 11)
		rev = 0;
	if (rev != parseInt(cpf.charAt(9)))
		return error;
	// Valida 2o digito	
	add = 0;
	for (i = 0; i < 10; i++)
		add += parseInt(cpf.charAt(i)) * (11 - i);
	rev = 11 - (add % 11);
	if (rev == 10 || rev == 11)
		rev = 0;
	if (rev != parseInt(cpf.charAt(10)))
		return error;

	return true;
}

const alertPlaceholder = document.getElementById('liveAlertPlaceholder')


	setTimeout(function () {
		document.getElementById("liveAlertPlaceholder").style.display = "none";
	}, 4000);

	setTimeout(function () {
		document.getElementById("Modal01").style.display = "none";
	}, 4000);
	
$(document).ready(function () {
	$("#myInput").on("keyup", function () {
		var value = $(this).val().toLowerCase();
		$("#myTable tr").filter(function () {
			$(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
		});
	});
});
//function myFunction() {
//	// Declare variables
//	var input, filter, table, tr, td, i, txtValue;
//	input = document.getElementById("myInput");
//	filter = input.value.toUpperCase();
//	table = document.getElementById('myTable');
//	tr = table.getElementsByTagName("tr");

//	// Loop through all table rows, and hide those who don't match the search query
//	for (i = 0; i < tr.length; i++) {
//		td = tr[i].getElementsByTagName("td")[0];
//		if (td) {
//			txtValue = td.textContent || td.innerText;
//			if (txtValue.toUpperCase().indexOf(filter) > -1) {
//				tr[i].style.display = "";
//			} else {
//				tr[i].style.display = "none";
//			}
//		}
//	}
//}