const openModal = document.getElementById("openModal");
const closeModal = document.getElementById("closeModal");
const modal = document.getElementById("noteModal");
const saveNote = document.getElementById("saveNote");
const notesContainer = document.querySelector(".notes");

let editingNote = null; 

openModal.addEventListener("click", () => {
    editingNote = null;
    document.getElementById("noteTitle").value = "";
    document.getElementById("noteDescription").value = "";
    modal.style.display = "flex";
});

closeModal.addEventListener("click", () => {
    modal.style.display = "none";
});

saveNote.addEventListener("click", () => {
    const title = document.getElementById("noteTitle").value;
    const description = document.getElementById("noteDescription").value;

    if (title.trim() === "" || description.trim() === "") {
        alert("Preencha todos os campos!");
        return;
    }

    if (editingNote) {
        
        editingNote.querySelector(".note-header").textContent = title;
        editingNote.querySelector(".note-body").textContent = description;
        editingNote = null;
    } else {
        
        const note = document.createElement("div");
        note.classList.add("note-item");
        note.innerHTML = `
            <div class="note-header">${title}</div>
            <div class="note-body">${description}</div>
            <div class="note-actions">
                <button class="edit-btn">Editar</button>
                <button class="delete-btn">Excluir</button>
            </div>
        `;

        
        note.querySelector(".delete-btn").addEventListener("click", () => {
            note.remove();
        });

        
        note.querySelector(".edit-btn").addEventListener("click", () => {
            editingNote = note;
            document.getElementById("noteTitle").value = note.querySelector(".note-header").textContent;
            document.getElementById("noteDescription").value = note.querySelector(".note-body").textContent;
            modal.style.display = "flex";
        });

        notesContainer.appendChild(note);
    }

    document.getElementById("noteTitle").value = "";
    document.getElementById("noteDescription").value = "";
    modal.style.display = "none";
});
