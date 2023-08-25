
/* =========== Modal para historial =========== */
const HistorialModal = document.getElementById('HistorialModal')
if (HistorialModal) {
    HistorialModal.addEventListener('show.bs.modal', event => {
        // Button that triggered the modal
        const button = event.relatedTarget
        // Extract info from data-bs-* attributes
        const recipient = button.getAttribute('data-bs-document')
        // If necessary, you could initiate an Ajax request here
        // and then do the updating in a callback.

        // Update the modal's content.
        const modalTitle = HistorialModal.querySelector('.modal-title')
        const modalBodyInput = HistorialModal.querySelector('.modal-body input')

        modalTitle.textContent = `Historial de ${recipient}`
        modalBodyInput.value = recipient
    })
}

/* LLenar dropbox del historial */