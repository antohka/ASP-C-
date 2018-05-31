$(document).ready(function () {
    $(".btn").click(function () {
        var arr = [];
        var name = $("#name[name='name']").val();
        var secondName = $("#secondname[name='secondname']").val();
        var adress = $("#adress").val();
        var weight = $("#weight[name='weight']").val();
        var comment = $("#comment").val();
        var radio = $("input[name=optradio]:checked").val();
        arr.push(name);
        arr.push(secondName);
        arr.push(adress);
        arr.push(weight);
        arr.push(comment);
        arr.push(radio);
        if (arr[0] && arr[1] && arr[2] && arr[3] && arr[4]) {
            $.ajax({
                type: 'POST',
                url: '/Home/AjaxTest',
                data: {
                    Name: arr[0],
                    SecondName: arr[1],
                    Adress: arr[2],
                    Weight: arr[3],
                    Comment: arr[4],
                    Radio: arr[5]
                },           
                success: function (str) {
                    console.log(str);
                    $("h1").text("Стоимость доставки: " + str);
                },
                error: function () {
                    alert("Произошел сбой. Возможно не подключена база данных ил параметр вес введен не в прафильном формате(количество граммов необходимо водить через запятую)");
                }
            });
        } else {
            alert("Заполните, пожалуйста, все поля");
        }
    });
});