document.addEventListener("trix-attachment-remove", function (event) {
    const attachment = event.attachment;
    const url = attachment.getAttribute("url");
    if (url) {
        fetch("/uploads/trix?url=" + encodeURIComponent(url), {
            method: "DELETE"
        }).catch(err => console.error("Delete failed:", err));
    }
});

document.addEventListener("trix-attachment-add", function (event) {
    const attachment = event.attachment;
    if (attachment.file) {
        uploadTrixFile(attachment);
    }
});

function uploadTrixFile(attachment) {
    const file = attachment.file;
    const formData = new FormData();
    formData.append("file", file);

    fetch("/uploads/trix", {
        method: "POST",
        body: formData
    })
    .then(response => {
        if (!response.ok) throw new Error("Upload failed.");
        return response.json();
    })
    .then(data => {
        attachment.setAttributes({
            url: data.url,
            href: data.url
        });
    })
    .catch(error => {
        console.error("Upload error:", error);
    });
}

