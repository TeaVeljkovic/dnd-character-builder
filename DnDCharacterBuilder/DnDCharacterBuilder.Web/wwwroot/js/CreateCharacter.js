$(document).ready(function () {
    $('.stat').on('change', function () {
        const atributeChanged = $(this).data("atribute-control");
        const abilityValue = $(this).val();
        const modifier = (parseInt(abilityValue) - 10) / 2;
        $(`input[type="text"][data-ability="${atributeChanged}"]`).val(modifier >= 0 ? '+' + Math.floor(modifier) : Math.floor(modifier))
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
                            const classSavingThrows = response.classSavingThrows || [];
                            const classSkillProficiencieBonus = response.classSkillProficiencieBonus || [];
                            const proficiencyDescription = response.proficiencyDescription || "";
                            const proficiencyChoiceCount = response.proficiencyChoiceCount || 0;

                            $('input[type="checkbox"][name="SelectedSkills"]').prop('disabled', true);
                            $('input[type="checkbox"][name="SelectedSkills"]').prop('checked', false);
                            $('#proficiencyDescription').text(proficiencyDescription);
                            $('input[type="checkbox"][name="save-prof"]').prop('checked', false);

                            classSkillProficiencieBonus.forEach(function (skillId) {
                                console.log("Enabling skill ID: " + skillId);
                                const checkbox = $(`input[type="checkbox"][id="${skillId}"]`);
                                if (checkbox.length) {
                                    checkbox.prop('disabled', false);
                                } else {
                                    console.error("Checkbox with ID " + skillId + " not found.");
                                }
                            });

                            $('.skillsCheckbox').on('change', function () {
                                const skillsLength = $('.skillsCheckbox:checked').length;
                                console.log("selection length: ", skillsLength);
                                console.log("proficiencyChoiceCount: ", proficiencyChoiceCount);
                                if (skillsLength > proficiencyChoiceCount) {
                                    console.log("I'm here." + `${$(this).val()}`);
                                    $(`input[type="checkbox"][id="${$(this).val()}"]`).prop('checked', false);
                                }
                            });

                            classSavingThrows.forEach(function (modifier) {
                                $(`input[type="checkbox"][id=${modifier}]`).prop('checked', true);
                            });
                        }
                        else {
                            console.log("error")
                        }


                    } catch (e) {
                        console.error("AJAX Error:" + e);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error: " + status + " - " + error);
                }
            });
        }
    })
});
