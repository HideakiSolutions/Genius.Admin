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
    var target64 = event.target.id.replace("-input", "-b64");
    document.getElementById(target).src = base64;
    document.getElementById(target64).value = base64;
    textArea.innerText = base64;
};

document.getElementById("companyStatute-input").addEventListener("change", (e) => {
    uploadImage(e);
});

document.getElementById("addressproof-input").addEventListener("change", (e) => {
    uploadImage(e);
});

document.getElementById("associateAddress-input").addEventListener("change", (e) => {
    uploadImage(e);
});

document.getElementById("associateDocument-input").addEventListener("change", (e) => {
    uploadImage(e);
});

document.getElementById("associateCompanyStatute-input").addEventListener("change", (e) => {
    uploadImage(e);
});

document.getElementById("associateDeclaredIncome-input").addEventListener("change", (e) => {
    uploadImage(e);
});