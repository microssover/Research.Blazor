

async function addApplicant(event) { 
    event.preventDefault();

    const applicant = {
        name: document.getElementById("name").value,
        name: document.getElementById("surname").value,
        name: document.getElementById("email").value,
        name: document.getElementById("jobType").value,
        //name: document.getElementById("status").value,
        name: document.getElementById("applicantDate").value,
        currentFlowId: null 
    }

    try {
        const response = await fetch("/CreateApplicant" {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON, stringify(applicant)
        });

        if (response.ok) {
            alert("Applicant created successfully!");
        } else {
            const errorText = await response.text();
            console.error("Error: ", errorText);
            alert("Error adding applicant :" + errorText);
        }
    } catch (error) {
        console.error("Error:", error);
        alert("An error occured.");
    }
}