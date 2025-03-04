const { type } = require("jquery");

function  getAllEmps() {
    //alert('u clicked button')
    //send ajax request to web api
    $.ajax({
        url: "http://localhost:5290/api/Employee/GetAllEmps",
        type: "GET",
        success: function (res) {
            alert("success call to api");
            console.log(res);
            var str = "<table border=1>";
            str += "<tr><th>Ecode</th><th>Ename</th><th>salary</th><th>depid</th></tr>";
            res.forEach(e => {
                str += "<tr>";
                str += "<th>" + e.empid + "</th>";
                str += "<th>" + e.name + "</th>";
                str += "<th>" + e.salary + "</th>";
                str += "<th>" + e.deptid + "</th>";
                str += "</tr>";
            });
            str += "<table>";
            $("#d1").html(str);
        },
        error: function (err) {
            alert("Failed to call api")
        }

    });//close of ajax
}//close of 
function getEmpById() {
   let id = $("#empid").val();
    $.ajax({
        url: "http://localhost:5290/api/Employee/GetEmpById/" + id,
        type: "GET",
        success: function (res) {
            console.log(res);
            $("#txtName").val(res.name);
            $("#txtsal").val(res.salary);
            $("#txtdid").val(res.deptid);
        },
        error: function (err) {
            alert("failed");
        }
    });
}
function addemp() {
    let empObj = {
        "empid": $("#empid").val(),
        "name": $("#txtName").val(),
        "salary": $("#txtsal").val(),
        "deptid": $("#txtdid").val()
    };
    $.ajax({
        url: "http://localhost:5290/api/Employee/AddEmp",
        type: "POST",
        data: JSON.stringify(empObj),
        contentType :"application/json;charset=UTF-8",
        success: function (res) {
            console.log(res);
            alert("Data inserted");
            getAllEmps();
        },
        error: function(err){
        alert(err.responseText);
        }
    });
}
function deleteEmpById() {
    let id = $("#empid").val();
    $.ajax({
        url: "http://localhost:5290/api/Employee/DeleteByID/"+id,
        type: "DELETE",
        success: function (res) {
            console.log(res);
            //alert("record deleted");
            alert(res);
            getAllEmps();

        },
        error: function (err) {
            alert("failed" + err.responseText);
        }
    });
}
function updateEmp() {
    //var id = $(empid).val();
    let empObj = {
        "empid": $("#empid").val(),
        "name": $("#txtName").val(),
        "salary": $("#txtsal").val(),
        "deptid": $("#txtdid").val()
    };
    $.ajax({
        url: "http://localhost:5290/api/Employee/UpdateEmp/" + empObj.empid,
        type: "PUT",
        data: JSON.stringify(empObj),
          contentType: "application/json;charset=UTF-8",
        success: function(res){
            console.log(res);
            alert("recoded updated");
            getAllEmps();
         },
        error: function (err) {
            alert(err.responseText);
        }

    });
}
