var images = [];
var imagesJson = "";
var Project = Project || {
    init: function () {
        Project.ListenerBtnAddImgToList();
        Project.updateList();
        $("#btn_load").hide();
    },
    ListenerBtnAddImgToList: function () {
        $("#button_add").click(function () {
            $("#button_add").attr("disabled", true);
            $("#button_add").hide();
            $("#btn_load").show();
            
            var valor = $("#string_imagen").val();
            $("#string_imagen").val("");
            if (images.length < 5) {
                //es img de google drive
                if (valor.includes("https://drive.google.com/file/d/")) {
                    var reg = new RegExp('(?<=\/d/).*(.+?(?=/))');
                    var resultado = reg.exec(valor)
                    valor = "https://drive.google.com/uc?id=" + resultado[0] + ""
                } 
                //checkeo el tipo
                var img = new Image();
                var video = document.createElement("video");
                video.oncanplay = function () {
                    Project.loadType({ Url: valor, TypeFile:"Video"});
                }
                video.onerror = function () {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error de archivo',
                        text: 'Por favor ingrese una URL de un archivo multimedia...'
                    })
                    $("#button_add").attr("disabled", false);
                    $("#btn_load").hide();
                    $("#button_add").show();
                }
                img.onload = function () {
                    Project.loadType({ Url: valor, TypeFile :"Image"});
                }
                img.onerror = function (arg) {
                    video.src = arg.currentTarget.src;
                }
                img.src = valor
            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: 'Tope alcanzado',
                    text: 'No se pueden incluir mas de 5 archivos multimedia...'

                })
                $("#btn_load").hide();
                $("#button_add").show();

            }
        });
    },
    loadType: function (data) {
        images.push(data)
        Project.DrawTableImages();

    },
    updateList: function () {
        if (images.length > 0) {
            document.getElementById('images').value = JSON.stringify(images);
        } else {
            document.getElementById('images').value = null;
        }
    },
    ListenerBtnRemoveImgFromList: function () {
        $(".remove").click(function () {
            var remove = $(this).attr("data-image");
            var index = images.findIndex(images => images.Url == remove);
            images.splice(index, 1);
            Project.DrawTableImages();
        });
    },
    DrawTableImages: function () {
        Project.updateList();
        $("#container-images tbody").html("");
        for (var i = 0; i < images.length; i++) {
            $("#container-images tbody").append('<tr><th scope="row">' + images[i].TypeFile + ' </th><td>' + images[i].Url + '</td><td>&nbsp; &nbsp;<a data-image="' + images[i].Url + '" class="btn btn-primary remove">Eliminar</a></td></tr>')

        }

        Project.ListenerBtnRemoveImgFromList();
        $("#button_add").attr("disabled", false);
        $("#btn_load").hide();
        $("#button_add").show();

    }




}