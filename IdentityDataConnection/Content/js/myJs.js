function Register() {
	var id = document.getElementById("id").value;
	var maGS = document.getElementById("MaGS").value;
	var link = "/GiaSuOnline/DangKyKhoaHoc?id=" + id + "&MaGS=" + maGS;
	$.get(link, function (data, status) {
		if (data.result != null) alert(data.result);
		else {
			document.getElementById("content").innerHTML = data;
		}
		//alert(data.result);
		//
	})
		
}