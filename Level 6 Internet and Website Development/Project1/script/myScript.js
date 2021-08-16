// Functions for the vertical animation//

// Function to replay the vertical animation.
function replay() {
    var parent;
    var animation;
    var newAnimation;
    parent = document.getElementById("verticalBannerColumn")
    animation = document.getElementById("verticalBanner");
    newAnimation = animation.cloneNode(true);
    parent.replaceChild(newAnimation, animation);
    }

// Function repsonding to the (i) information icon on the vertical animation.
function info() {
    alert("This is an advertisement for the tourism arm of Trust Tairawhiti, the regional development trust for Te Tairawhiti.")
    }

// Function responding to the X exit icon on the vertical animation.
function exit() {
    var verticalBanner;
    verticalBanner = document.getElementById("verticalBanner");
    verticalBanner.style.display = "none";
    }



// Functions for the Booking page

// Global variables to save inputed form data
var clientFirstName;
var clientFamilyName;
var clientCheckInDate;
var clientCheckOutDate;
var clientCooking;
var clientRecreationEquipment;
var clientSwimmingExperience;
var clientSurfingExperience;
var clientSurfingLessons;
var clientBushExperience;
var clientTrackInformationPack;
var bookingNumberAdults;
var bookingNumberChildren;
var bookingNumberLodges;
var bookingColourWelcomePack;
var clientEmail;
var clientConservationAgreement;

/* Upon clicking the 'next' button this function loads the next section of the booking form, saves the values entered as global variables and updates the progress bar.*/
function nextSection(sectionName) {
    var nextSectionID;
    var newSectionName
    var currentSectionID;
    var newProgressValue;
    var newProgress;

    switch (sectionName) {
        case 'details':
            currentSectionID = document.getElementById("bookingDetails");    
            nextSectionID = document.getElementById("activityExperience");
            newSectionName = 'activities';
            clientFirstName = document.getElementById("firstName").value;
            clientFamilyName = document.getElementById("familyName").value;
            clientCheckInDate = document.getElementById("checkInDate").value;
            clientCheckOutDate = document.getElementById("checkOutDate").value;
            if (document.getElementById("cookingYes").checked) {
                clientCooking = document.getElementById("cookingYes").value;
            }
            else {
                clientCooking = document.getElementById("cookingNo").value;   
            }
            if (document.getElementById("recreationEquipmentYes").checked) {
                clientRecreationEquipment = document.getElementById("recreationEquipmentYes").value;
            }
            else {
                clientRecreationEquipment = document.getElementById("recreationEquipmentNo").value;   
            }
            break;
        case 'activities':
            clientSwimmingExperience = document.getElementById("swimmingExperience").value;
            clientSurfingExperience = document.getElementById("surfingExperience").value;
            clientSurfingLessons = document.getElementById("surfingLessons").value;
            clientBushExperience = document.getElementById("bushExperience").value;
            clientTrackInformationPack = document.getElementById("trackInformation").value;
            currentSectionID = document.getElementById("activityExperience");
            nextSectionID = document.getElementById("bookingNumbers");
            newSectionName = 'numbers';
            break;
        case 'numbers':
            bookingNumberAdults = document.getElementById("numberAdults").value;
            bookingNumberChildren = document.getElementById("numberChildren").value;
            bookingNumberLodges = document.getElementById("numberLodges").value;
            bookingColourWelcomePack = document.getElementById("colourWelcomePack").value;
            currentSectionID = document.getElementById("bookingNumbers");
            nextSectionID = document.getElementById("contactDetails");
            newSectionName = 'contact'
            break;
        case 'contact':
            clientEmail = document.getElementById("bookingEmail").value;
            if (document.getElementById("conservationAgreement").checked) {
                clientConservationAgreement = "Yes";
            }
            else {
                clientConservationAgreement = "No";
            }
            currentSectionID = document.getElementById("contactDetails");
            nextSectionID = document.getElementById("confirmationSummary");
            newSectionName = 'confirmation';
            break;
    }
    currentSectionID.style.display = "none";
    nextSectionID.style.display = "initial";
    newProgress = document.getElementById("progressBar");
    newProgressValue = updateProgressBar(newSectionName);
    newProgress.style.width = newProgressValue;
    newProgress.innerHTML = newProgressValue;
}
/*Loads the previous section upon clicking the 'previous' button*/
function previousSection(sectionName) {
    var previousSectionID;
    var currentSectionID;
    var newSectionName;

    switch (sectionName) {
        case 'details':
            currentSectionID = document.getElementById("bookingDetails");    
            previousSectionID = document.getElementById("bookingDetails");
            newSectionName = "details";
            break;
        case 'activities':
            currentSectionID = document.getElementById("activityExperience");
            previousSectionID = document.getElementById("bookingDetails");
            newSectionName = "details";
            break;
        case 'numbers':
            currentSectionID = document.getElementById("bookingNumbers");
            previousSectionID = document.getElementById("activityExperience");
            newSectionName = "activities";
            break;
        case 'contact':
            currentSectionID = document.getElementById("contactDetails");
            previousSectionID = document.getElementById("bookingNumbers");
            newSectionName = "numbers";
            break;
    }

    currentSectionID.style.display = "none";
    previousSectionID.style.display = "initial";
    newProgress = document.getElementById("progressBar");
    newProgressValue = updateProgressBar(newSectionName);
    newProgress.style.width = newProgressValue;
    newProgress.innerHTML = newProgressValue;
}
/*Updates the progress bar upon clicking the 'previous' or 'next' buttons*/
function updateProgressBar(newSectionName) {
    var newValue;
    var newProgress;
    switch (newSectionName) {
        case 'details':
            newValue = "0%";
            break;
        case 'activities':
            newValue = "25%";
            break;
        case 'numbers':
            newValue = "50%";
            break;
        case 'contact':
            newValue = "75%";
            break;
        case 'confirmation':
            newValue = "100%";
            break;
    }
    return newValue;
}
/* Places all the entered values into the confirmation summary. Each section of the form has its own summary variable.*/
function submit() {
    nextSection('contact');
    var bookingDetailsSummary = "<table> <caption>Booking Details</caption> <tr> <td class='confirmationTableLeftCol'>First Name:</td> <td class='confirmationTableRightCol'>" + clientFirstName + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Family Name:</td> <td class='confirmationTableRightCol'>" + clientFamilyName + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Check In Date:</td> <td class='confirmationTableRightCol'>" + clientCheckInDate + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Check Out Date:</td> <td class='confirmationTableRightCol'>" + clientCheckOutDate + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Access to cooking facilities:</td> <td class='confirmationTableRightCol'>" + clientCooking + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Access to recreational equipment:</td> <td class='confirmationTableRightCol'>" + clientRecreationEquipment + "</td> </tr> </table>";
    
    var activityExperienceSummary = "<table> <caption>Activity Experience</caption> <tr> <td class='confirmationTableLeftCol'>Ocean swimming experience level:</td> <td class='confirmationTableRightCol'>" + clientSwimmingExperience + "</td> </tr> <tr> <td class='confirmationTableLeftCol'> Surfing experience level:</td> <td class='confirmationTableRightCol'>" + clientSurfingExperience + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Surf lessons required:</td> <td class='confirmationTableRightCol'>" + clientSurfingLessons + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Bush experience level:</td> <td class='confirmationTableRightCol'>" + clientBushExperience + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Local track information pack:</td> <td class='confirmationTableRightCol'>" + clientTrackInformationPack + "</td> </tr> </table>";

    var guestLodgeInformationSummary = "<table> <caption>Guest and Lodge Information</caption> <tr> <td class='confirmationTableLeftCol'>Number of adults:</td> <td class='confirmationTableRightCol'>" + bookingNumberAdults + "</td> </tr> <tr> <td class='confirmationTableLeftCol'> Number of children:</td> <td class='confirmationTableRightCol'>" + bookingNumberChildren + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Number of lodges:</td> <td class='confirmationTableRightCol'>" + bookingNumberLodges + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Colour of welcome pack:</td> <td class='confirmationTableRightCol'>" + bookingColourWelcomePack + "</td> </tr> </table>";

    var contactConservation = "<table> <caption>Contact Information and Conservation</caption> <tr> <td class='confirmationTableLeftCol'>Email address:</td> <td class='confirmationTableRightCol'>" + clientEmail + "</td> </tr> <tr> <td class='confirmationTableLeftCol'>Agreement to Piha Native <br>Conservation Initiative Agreement:</td> <td class='confirmationTableRightCol'>" + clientConservationAgreement + "</td> </tr> </table>";
    
    var bookingSummary = "<section class='confirmationTable'> <h2>Confirmation Summary</h2>" + bookingDetailsSummary + activityExperienceSummary + guestLodgeInformationSummary + contactConservation +"</section>";
    
    document.getElementById("confirmationSummary").innerHTML = bookingSummary;
}
