

function getIdFromUrl(url) { return url.match(/[-\w]{25,}/); }




function previewImg(comp) {

    let id = parseInt(comp.id);
    var url = document.getElementById(`UrlImg${id}`).value;




    if (url.includes("https://drive.google.com/file/")) {
        url = "https://drive.google.com/uc?id=" + getIdFromUrl(url);
    }

    if (url != null) {


        // to know if the element img with this id exist
        var imgPreview = document.getElementById(`imgPreview${id}`);


        if (imgPreview == null) {

            document.getElementById(`Preview${id}`).innerHTML +=
                `<img src="${url}" id="imgPreview${id}" name="UrlImg1" alt="preview" width="500" onerror="deleteImg(${id})" style="display:block"/>`;

        } else {

            imgPreview.src = url;
            document.getElementById(`imgPreview${id}`).style.display = "block";
        }

        document.getElementById(`UrlImg${id}`).readOnly = true;
        document.getElementById(`btnDelete${id}`).style.display = "block";
        document.getElementById(`${id}`).style.display = "none";
        document.getElementById(`UrlImg${id}`).value = url;

    }

    if (id < 3) {

        var idNext = parseInt(id) + 1;

        document.getElementById(`Preview${idNext}`).style.display = "block";
    }



}











function deleteImg(id) {
    document.getElementById(`UrlImg${id}`).readOnly = false;
    document.getElementById(`imgPreview${id}`).style.display = "none";
    document.getElementById(`UrlImg${id}`).value = "";
    document.getElementById(`${id}`).style.display = "block";
    document.getElementById(`btnDelete${id}`).style.display = "none";
    document.getElementById(`UrlImg${id}`).style.display = "block";
}



