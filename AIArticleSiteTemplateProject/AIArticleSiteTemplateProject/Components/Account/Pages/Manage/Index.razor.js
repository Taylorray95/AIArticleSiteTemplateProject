 function readFileAsDataURL(fileBytes) {

            console.log("funct called");
            return new Promise((resolve, reject) => {
                const blob = new Blob([new Uint8Array(fileBytes)], { type: 'image/png' }); // Adjust the type if necessary
                const reader = new FileReader();
                reader.onload = () => resolve(reader.result);
                reader.onerror = reject;
                reader.readAsDataURL(blob);
            });
        }