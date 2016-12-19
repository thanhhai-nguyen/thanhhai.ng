// JavaScript Document
function check()
{
	var tag_ht = document.getElementById("name");
	var address = document.getElementById("address");
	var number = document.getElementById("number");
	var loi = false;
	var mau= /[a-zA-Z]+/;
	var mauAdd= /[a-zA-Z0-9]10+/;
	var mauNum= /[1-9](8+)/;
	if (mau.test(tag_ht.value) == false)
	{
		tag_ht.focus();
		var t = document.getElementById("e1");
		t.innerHTML = "Không đúng chuẩn";
		loi = true;
	}
	else 
	{
	    var t = document.getElementById("e1");
		t.innerHTML = "";
	}
	// Dung if de kiem tra cac control con lai 
	if (mauAdd.test(address.value) == false)
	{
		address.focus();
		var t = document.getElementById("e2");
		t.innerHTML = "Không đúng chuẩn";
		loi = true;
	}
	else 
	{
	    var t = document.getElementById("e2");
		t.innerHTML = "";
	}
	/////////////////
	if (mauNum.test(number.value) == false)
	{
		number.focus();
		var t = document.getElementById("e3");
		t.innerHTML = "Nhập từ 8-11 số";
		loi = true;
	}
	else 
	{
	    var t = document.getElementById("e3");
		t.innerHTML = "";
	}
	// Doan code nay luu account
	if (loi == false) {
		localStorage.setItem("hoten", tag_ht.value);
		localStorage.setItem("address", address.value);
	    localStorage.setItem("number", number.value);
		alert("Cảm ơn quý khách đã ủng hộ");
	}
	else{
	alert("Đặt hàng thất bại");
	}
}

function countthun()
{
	var t= document.getElementById("many");
	var s;
	s= t.value*200;
	document.getElementById("print").innerHTML= s+".000đ";
}

function countsomi()
{
	var t= document.getElementById("many");
	var s;
	s= t.value*150;
	document.getElementById("print").innerHTML= s+".000đ";
}
function countjean()
{
	var t= document.getElementById("many");
	var s;
	s= t.value*500;
	document.getElementById("print").innerHTML= s+".000đ";
}

function countshort()
{
	var t= document.getElementById("many");
	var s;
	s= t.value*300;
	document.getElementById("print").innerHTML= s+".000đ";
}

function countaokhoac()
{
	var t= document.getElementById("many");
	var s;
	s= t.value*400;
	document.getElementById("print").innerHTML= s+".000đ";
}


function countgiay()
{
	var t= document.getElementById("many");
	var s;
	s= t.value*100;
	document.getElementById("print").innerHTML= s+"$";
}