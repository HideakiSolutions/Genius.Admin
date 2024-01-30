const input = document.getElementById("selectAvatar");
const avatar = document.getElementById("avatar");
const textArea = document.getElementById("textArea");

const convertBase64 = (file) => {
    return new Promise((resolve, reject) => {
        const fileReader = new FileReader();
        fileReader.readAsDataURL(file);

        fileReader.onload = () => {
            resolve(fileReader.result);
        };

        fileReader.onerror = (error) => {
            reject(error);
        };
    });
};

const uploadImage = async (event) => {
    const file = event.target.files[0];
    const base64 = await convertBase64(file);
    var target = event.target.id.replace("-input", "");
    document.getElementById(target).src = base64;
    textArea.innerText = base64;
};

document.getElementById("selfie-input").addEventListener("change", (e) => {
    uploadImage(e);
});
document.getElementById("documentproof-input").addEventListener("change", (e) => {
    uploadImage(e);
});
document.getElementById("addressproof-input").addEventListener("change", (e) => {
    uploadImage(e);
});
document.getElementById("incomeproof-input").addEventListener("change", (e) => {
    uploadImage(e);
});





