// JavaScript Document
function khoitao()
{
	localStorage.setItem("sl", "0");
}

var slmua = 0;
function getSLMUA(id)
{
		var t= document.getElementById(id);
		slmua = t.value;
}

function tim(ma)
{
		var sl=parseInt(localStorage.getItem("sl"));
		for(var i=0; i<sl; i++)
		{
			var v = localStorage.getItem("sp"+i);
			if(v!=null && v!="undefined")
			{
			var arr=v.split("-");
			if(ma==arr[0])
				return i;
			}
		}
		return -1;
}

function add(ma, ten, hinh, gia, size)
	{
		var kq=tim(ma);
		if(kq==-1)
		{
			//lấy số lượng hàng
			var sl=parseInt(localStorage.getItem("sl"));
			alert("Add Success");
			localStorage.setItem("sp" + sl, ma + "-" + ten + "-" +hinh + "-" + gia + "-" + slmua);
			sl++;
			localStorage.setItem("sl", sl);
		}
		else
		{
			//Đã có sp này trong kho
			localStorage.setItem("sp" + kq, ma + "-" + ten + "-" +hinh + "-" + gia + "-" + slmua);
		}
	}
	
function view()
{
	var t=document.getElementById("d");
	var sl = parseInt(localStorage.getItem("sl"));
	var s="<table border='1' bordercolor='#000000' align='center' bgcolor='#C6E0DC'>";
	var tong = 0;
	for(i=0; i<sl; i++)
	{
		//lấy thông tin sp thứ i
		var sp=localStorage.getItem("sp"+i);
		if(sp!=null && sp!="undefined")
		{
		var arr= sp.split("-");
		s+="<tr>";
		s+= "<td width='50'>" + arr[0] + "</td>";
		s+= "<td width='150'>" + arr[1] + "</td>";
		s+= "<td><img src='"+arr[2] + "' width='200px' height='200px'></td>";
		s+= "<td width='100'>" + arr[3] + ".000đ</td>";
		s+= "<td><p>Số lượng  <input type='number' value='" + arr[4] + "'></p></td>";
		s+= "<td><p>Size<input type='text'" + arr[5] + "'></p></td>";
		s+="<td width='50'><input type='button' value='Bỏ' onClick='del("+arr[0]+")'></td>";
		s+= "</tr>";
		tong+= arr[3]*arr[4];
		}
	}
	s+="</table>";
	s+="<p style='color:#F41515; font-size:30px;  background-color:#09F ;border-radius:50px'>Tổng tiền: "+ tong +".000đ</p>";
	t.innerHTML = s;
}

function del(ma)
{
	var kq = tim(ma);
	alert("Remove success");
	localStorage.removeItem("sp"+kq);
	view();
}