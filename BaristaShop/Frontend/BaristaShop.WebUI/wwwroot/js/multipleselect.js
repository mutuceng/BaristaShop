const selectElement = document.getElementById('secimler');
const selectedOptionsDiv = document.getElementById('selectedOptions');
const hiddenField = document.getElementById('SelectedFeatures');
const selectedValues = new Set(); // Seçilen değerlerin tekrarını önlemek için Set kullanıyoruz

// Select kutusundaki değişiklikleri dinle
selectElement.addEventListener('dblclick', function () {
    const selectedOptionText = selectElement.options[selectElement.selectedIndex].text;
    const selectedOptionValue = selectElement.value;

    // Eğer seçenek daha önce seçilmişse ekleme
    if (!selectedValues.has(selectedOptionValue)) {
        selectedValues.add(selectedOptionValue);

        // Yeni kutu oluştur
        const box = document.createElement('div');
        box.className = 'selected-box mt-1 p-2 border rounded';
        box.style.display = "inline-block";
        box.style.marginRight = "10px";
        box.innerHTML = `${selectedOptionText} <span class="remove-btn" style="color: red; cursor: pointer;">&times;</span>`;

        // Kutuya çarpı işareti tıklama olayını ekle
        box.querySelector('.remove-btn').addEventListener('click', function () {
            selectedValues.delete(selectedOptionValue); // Seçim set'ten kaldırılıyor
            box.remove(); // Kutu siliniyor
            updateHiddenField(); // Seçimler değişince hidden field'ı güncelle
        });

        // Kutu div'e ekle
        selectedOptionsDiv.appendChild(box);
    }
    updateHiddenField();
    console.log(hiddenField.value);
});

function updateHiddenField() {
    hiddenField.value = Array.from(selectedValues).join(','); // Değerleri `"id12345"` formatında virgülle birleştir
}
