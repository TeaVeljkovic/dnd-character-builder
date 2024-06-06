$(document).ready(function () {
    $('.stat').on('change', function () {
        updateModifiers();
        updateSkills();
        const atributeChanged = $(this).data("atribute-control");
        const abilityValue = $(this).val();
        const modifier = (parseInt(abilityValue) - 10) / 2;
        $(`.statmod[data-ability="${atributeChanged}"]`).val(modifier >= 0 ? '+' + Math.floor(modifier) : Math.floor(modifier))
    })

    function updateModifiers() {
        $('.modifier-value').map(function (index, element) {
            const shortenedAbility = $(element).data('ability');
            const abilityVal = $(`[data-atribute-control="${shortenedAbility}"]`).val();
            const isAbilitySelected = $(`#${shortenedAbility}`).prop('checked');
            const modifier = (parseInt(abilityVal) - 10) / 2 + (isAbilitySelected ? 1 : 0);
            $(element).val(modifier >= 0 ? '+' + Math.floor(modifier) : Math.floor(modifier) || "0");
        });
    }

    function updateSkills() {
        $('.skills-modifier').map(function (index, element) {
            const shortenedAbility = $(element).data('ability');
            const abilityVal = $(`[data-atribute-control="${shortenedAbility}"]`).val();
            const skillName = $(element).attr('name');
            const checkboxId = $(`[data-checkbox-control="${skillName}"`).attr('id');
            console.log('checkboxId: ', checkboxId);
            const isAbilitySelected = $(`#${checkboxId}`).prop('checked');
            console.log('isChecked: ', isAbilitySelected)
            const modifier = (parseInt(abilityVal) - 10) / 2 + (isAbilitySelected ? 1 : 0);
            $(element).val(modifier >= 0 ? '+' + Math.floor(modifier) : Math.floor(modifier) || "0");
        });
    }

    //function updateSpeed() {
    //    $('.speed').prop('value', )
    //}

    $('#selectedRace').on('change', function () {
        const selectedRaceId = $(this).val();
        console.log('Selected Race');

        if (selectedRaceId) {
            $.ajax({
                url: '/Race/GetAttributesForRace',
                type: 'GET',
                data: { raceId: selectedRaceId },
                success: function (response) {
                    console.log(response);
                    try {
                        if (response) {
                            const raceSpeed = response.speed || 0;
                            const ageInfo = response.ageInfo || "";
                            const size = response.size || "";
                            const sizeInfo = response.sizeInfo || "";
                            const alignmentInfo = response.alignmentInfo || "";

                            $('#sizeDescription').text(sizeInfo);
                            $('#ageDescription').text(ageInfo);
                            $('#alignmentDescription').text(alignmentInfo);
                            $('#speed').prop('value', raceSpeed);
                        }
                    } catch (e) {
                        console.error("AJAX Error:" + e);
                    }
                }
            })
        }
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
                            const hitDie = response.hitDie || "";

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
                                updateSkills();
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
                            updateModifiers()
                            updateSkills();
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
