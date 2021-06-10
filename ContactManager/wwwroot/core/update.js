//#region Variables
let multiplePhotoCount = document.getElementById("editAccommodationPhotoCount").value,
    currentImageCount = 0,
    allowFileCount = 0,
    editPhotoError = document.getElementById("tab2Error"),
    gallery = document.getElementById("gallery");
let divColElementLenght = document.querySelectorAll("#gallery .imageBox").length;
let getAllColElements = document.querySelectorAll("#gallery .imageBox");
var lastDataId = getAllColElements[getAllColElements.length - 1];
const detailPhotos = document.getElementById("DetailPhotos");
const data = [];
let fileArray = [];
let removedPhotoIds = [];
let index = 0;
let editfileAll = null;
//#endregion Variables

//#region input file change method
function onChange(input) {
    if (fileSizeCheck(input) === true) {
        var fileUpload = $(input);
        let DivColElementCount = checkCurrentImageCount() + input.files.length;

        if (parseInt(fileUpload.get(0).files.length) > multiplePhotoCount) {
            editPhotoError.classList.remove("d-none");
            editPhotoError.innerHTML = `You are allowed to upload a maximum of ${multiplotoCount} files!`;
        } else if (DivColElementCount > multiplePhotoCount) {
            editPhotoError.classList.remove("d-none");
            detailPhotos.value = "";
            editPhotoError.innerHTML = `You are allowed to upload a maximum of ${multiplotoCount} files!`;
        }
        else {
            maxFileLimit(input);
        }
    }
    else {
        editPhotoError.classList.remove("d-none");
        editPhotoError.innerHTML = "The file size should be 2 mb and type jpeg, jpg, png!";
        detailPhotos.value = '';
    }
}

//#endregion input file change method

//#region file size and type check
function fileSizeCheck(input) {
    for (var i = 0; i < input.files.length; i++) {
        const fileSize = input.files[i].size;
        const fileMathRound = (fileSize / 1024) / 1024;
        const checkFileType = fileTypeCheck(input.files[i]);

        if (fileMathRound <= 2 && checkFileType === true) {
            return true;
        }
        else {
            return false;
        }
    }
}

function fileTypeCheck(file) {
    const parts = file.name.split('.');
    switch (parts[1].toLowerCase()) {
        case 'jpg':
        case 'jpeg':
        case 'png':
            return true;
    }
    return false;
}
//#endregion file size and type check

//#region data transfer class
class _DataTransfer {
    constructor() {
        return new ClipboardEvent("").clipboardData || new DataTransfer();
    }
}
//#endregion data transfer class

//#region data transfer class instance
const dataTransfer = new _DataTransfer();
//#endregion data transfer class instance

//#region use unique id
var identity = parseInt($(lastDataId).children(".card").children(".card-body").children(".border").attr("data-id")) + 1;
//#endregion use unique id

//#region check file limit count
function maxFileLimit(input) {
    //#region add files in object
    var fileObject = {};
    for (var i = 0; i < input.files.length; i++) {
        fileObject = { Id: identity++, file: input.files[i] };
        fileArray.push(fileObject);
    }
    //#endregion add files in object

    //#region Loop through the FileList and render image files as thumbnails.
    var files = input.files; // FileList object
    for (var k = 0, f; f = files[k]; k++) {
        // Only process image files.
        if (!f.type.match('image.*')) {
            continue;
        }

        var reader = new FileReader();

        // Closure to capture the file information.
        reader.onloadend = () => readerEndHandler()
        reader.onload = (function (theFile) {
            return function (e) {
                // Render thumbnail.
                addHtmlImage(e, theFile);
            };
        })(f);

        // Read in the image file as a data URL.
        reader.readAsDataURL(f);
    }
    //#endregion Loop through the FileList and render image files as thumbnails.

    //#region file reader call addhtmlimage and add html image
    function addHtmlImage(e, theFile) {
        var divClass_col = document.createElement("div");

        if (multiplePhotoCount == 2) {
            divClass_col.className = "col-md-6 imageBox";
        }
        else if (multiplePhotoCount == 3) {
            divClass_col.className = "col-md-4 imageBox";
        }
        else if (multiplePhotoCount == 4) {
            divClass_col.className = "col-md-3 imageBox";
        }
        else if (multiplePhotoCount == 5) {
            divClass_col.className = "col-md-4 imageBox";
        }
        else if (multiplePhotoCount == 6) {
            divClass_col.className = "col-md-4 imageBox";
        }
        else {
            divClass_col.className = "col-md-12 imageBox";
        }

        var singleImage = document.createElement("div");
        singleImage.className = "card e-co-product border";

        var carOverloy = document.createElement("div");
        carOverloy.className = "card-body d-flex justify-content-center product-info";

        var buttonDelete = document.createElement("button");
        buttonDelete.className = "delete-btn editDeleteButton border btn btn-cart btn-sm waves-effect waves-light";
        buttonDelete.type = "button";
        buttonDelete.style.color = "red";
        buttonDelete.setAttribute("onclick", "removePhotos(this)");
        buttonDelete.innerHTML = "<i class='mdi mdi-delete mr-1'></i>Delete";

        var buttonHeart = document.createElement("button");
        buttonHeart.className = "btn btn-quickview btn-sm waves-effect waves-light quickview";
        buttonHeart.innerHTML = "<i class='mdi mdi-magnify'></i>";
        carOverloy.append(buttonDelete);
        carOverloy.append(buttonHeart);

        singleImage.innerHTML = ['<img style="height:230px" class="thumb" src="', e.target.result,
            '" title="', escape(theFile.name), '"/>'].join('');
        singleImage.append(carOverloy);
        divClass_col.append(singleImage);

        gallery.append(divClass_col);
    }
    //#endregion file reader call addhtmlimage and add html image

    //#region reader end handler
    var deleteButton = "";
    let divColElementsCount = "";
    detailPhotos.value = "";
    //File read olunandan sonra ishe salinan funksiya.
    //Lazim oldugu ucun file read funksiyasinda
    //html creat and add element istifade etmisinizse,
    //bu funksiyani istifade etmeden attributlari elde etmek olmur
    //tebii ki bezi istisnalar da var.

    function readerEndHandler() {
        deleteButton = document.querySelectorAll(".editDeleteButton")
        for (var h = 0; h < fileArray.length; h++) {
            deleteButton[h].setAttribute("data-id", fileArray[h].Id)
        }
        fileLimitCheck();
    }
    //#endregion reader end handler

    //#region input files limit check
    function fileLimitCheck() {
        divColElementsCount = checkCurrentImageCount();

        allowFileCount = multiplePhotoCount - divColElementsCount;

        if (divColElementsCount > multiplePhotoCount) {
            input.value = null;
            if (editPhotoError.classList.contains("d-none")) {
                editPhotoError.classList.remove("d-none");
            }
            editPhotoError.innerHTML = (`<p>You are allowed to upload a maximum of ${multiplotoCount} files!</p>`);
        }
        else if (divColElementsCount < multiplePhotoCount) {
            detailPhotos.value = "";
            if (editPhotoError.classList.contains("d-none")) {
                editPhotoError.classList.remove("d-none");
            }
            editfileAll = "";
            editPhotoError.innerHTML = (`<p>You must also add ${allowFileCount} files!</p>`);
        }
        else if (divColElementsCount == multiplePhotoCount) {
            editPhotoError.classList.add("d-none");
            editPhotoError.innerHTML = "";
            // datatransfere file -leri elave edir
            dataTransfer.clearData();
            for (let file of
                fileArray) {
                dataTransfer.items.add(file.file)
            }

            if (dataTransfer.files.length) {
                editfileAll = dataTransfer.files;
            }
        }
    }
    //#endregion input files limit check
}
//#endregion check file limit count

//#region delete function for files
function removePhotos(e) {
    e.parentElement.parentElement.parentElement.remove();
    divColElementLenght = checkCurrentImageCount();
    var dataId = e.getAttribute("data-id");
    getRemovedFileIds(dataId);
    let detailPhotos = document.getElementById("DetailPhotos");
    detailPhotos.removeAttribute("disabled");
    detailPhotos.setAttribute("required", "required");

    var i = fileArray.length;
    while (i--) {
        if (parseInt(fileArray[i].Id) === parseInt(dataId)) {
            fileArray.splice(i, 1);
        }
    }
    allowFileCount += 1;
    if (divColElementLenght < multiplePhotoCount) {
        if (editPhotoError.classList.contains("d-none")) {
            editPhotoError.classList.remove("d-none");
        }
        editPhotoError.innerHTML = (`<p>You must also add ${allowFileCount} files!</p>`);
        detailPhotos.value = '';
        editfileAll = '';
    }
}
//#endregion delete function for files

//#region checkCurrentImageCount
function checkCurrentImageCount() {
    var imageBoxesLength = document.getElementsByClassName("imageBox").length;
    currentImageCount = imageBoxesLength;
    return imageBoxesLength;
}
//#endregion checkCurrentImageCount

//#region removedFileIds
function getRemovedFileIds(id) {
    checkCurrentImageCount();
    removedPhotoIds.push(id);
    let dataToSend = JSON.stringify(removedPhotoIds);
    $("#RemovedPhotoIds").val(dataToSend);
}
//#endregion