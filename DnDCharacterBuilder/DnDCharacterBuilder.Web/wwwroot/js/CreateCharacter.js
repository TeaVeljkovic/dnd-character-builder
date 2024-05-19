$(document).ready(function () {
    $('.stat').on('change', function () {
        const atributeChanged = $(this).data("atribute-control");
        const abilityValue = $(this).val();
        const modifier = (parseInt(abilityValue) - 10) / 2;
        $(`[data-ability="${atributeChanged}"]`).val(modifier >= 0 ? '+' + Math.floor(modifier) : Math.floor(modifier))
    })

    $('#selectedClass').on('change', function () {
        const selectedClassId = $(this).val();
        console.log("Selected Class");

        if (selectedClassId) {
            $.ajax({
                url: '/Class/GetAttributesForClass',
                type: 'GET',
                data: { classId: selectedClassId },
                success: function (response) {
                    console.log(response);
                    try {
                        if (response) {
                            const proficiencyDescription = response.proficiencyDescription || "No description available";
                            const proficiencyChoiceCount = response.proficiencyChoiceCount || 0;
                            const classSavingThrows = response.classSavingThrows || [];
                            const classSkillProficiencieBonus = response.classSkillProficiencieBonus || [];

                            console.log("Proficiency Description: " + proficiencyDescription);
                            console.log("Proficiency Choice Count: " + proficiencyChoiceCount);
                            console.log("Class Saving Throws: ", classSavingThrows);
                            console.log("Class Skill Proficiencie Bonus: ", classSkillProficiencieBonus);
                        }
                        else {
                            console.log("error")
                        }
                    } catch (e) {
                        console.error("AJAX Error: " + status + " - " + error);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error: " + status + " - " + error);
                }
            });
        }
    })
});
