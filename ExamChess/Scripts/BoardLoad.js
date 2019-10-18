var game;
var lastChecker;
var checkersList;

$(document).ready(function () {
    var length;

    console.log($("#board"));
    console.log(length);

    //if (length == 12) {
    //    for (var row = 0; row < 8; row++) {
    //        if (row % 2 == 0) {
    //            for (var line = 0; line < 8; line++) {
    //                var div = document.createElement("div");
    //                $(div).attr("id", id);
    //                if (line % 2 == 0) {
    //                    $(div).addClass("boardSquare blackBackground")
    //                }
    //                else {
    //                    $(div).addClass("boardSquare whiteBackground")
    //                }
    //                $("#board").append(div);
    //                id++;
    //            }
    //        }
    //        else {
    //            for (var line = 0; line < 8; line++) {
    //                var div = document.createElement("div");
    //                $(div).attr("id", id);
    //                if (line % 2 == 0) {
    //                    $(div).addClass("boardSquare whiteBackground")
    //                }
    //                else {
    //                    $(div).addClass("boardSquare blackBackground")
    //                }
    //                $("#board").append(div);
    //                id++;
    //            }
    //        }
    //    }

    //    Checkers();

    //}

    //Move();

    
})

function Checkers() {
    var ids = checkersList["0"].Id;
    console.log(ids);
    for (var i = 0; i < $("#board").children().length / 2 - Math.sqrt($("#board").children().length) ; i++) {
        if ($($("#board").children()[i]).hasClass("blackBackground")) {
            var div = document.createElement("div");
            $(div).attr("id", ids);
            $(div).addClass("checkerCircle blackCheckers")
            $("#board").children()[i].append(div);

            ids++;
        }
    }

    for (var i = $("#board").children().length - 1; i > $("#board").children().length / 2 + Math.sqrt($("#board").children().length) ; i--) {
        if ($($("#board").children()[i]).hasClass("blackBackground")) {
            var div = document.createElement("div");
            $(div).addClass("checkerCircle whiteBackground")
            $("#board").children()[i].append(div);
        }
    }
}

function Move() {
    $($("#board").children()[41]).children().remove();
    var div = document.createElement("div");

    $($("#board").children()[52]).children().remove();
    var div = document.createElement("div");
    $(div).addClass("checkerCircle whiteBackground");
    console.log($("#board").children()[29]);
    $("#board").children()[29].append(div);

    $($("#board").children()[18]).children().remove();
    var div = document.createElement("div");
    $(div).addClass("checkerCircle blackCheckers");
    $("#board").children()[32].append(div);

    $($("#board").children()[20]).children().remove();
    var div = document.createElement("div");
    $(div).addClass("checkerCircle blackCheckers");
    $("#board").children()[52].append(div);
}

function MultipleMoves(checkerId, checkerClass) {

    console.log('\nIn');

    if (checkerId < 64) {

        var leftUpper = checkerId + Math.sqrt($("#board").children().length) - 1;
        var leftBottom = checkerId - Math.sqrt($("#board").children().length) - 1;
        var rightUpper = checkerId + Math.sqrt($("#board").children().length) + 1;
        var rightBottom = checkerId - Math.sqrt($("#board").children().length) + 1;

        console.log('\nCheckerId: ' + checkerId);

        if (leftUpper < 64) {

            if ($($("#board").children()[leftUpper]).hasClass("blackBackground") && $($($("#board").children()[leftUpper]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftUpper]).children().length != 0) {
                var id = leftUpper + Math.sqrt($("#board").children().length) - 1;
                console.log('LeftUpperId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

                        MultipleMoves(id);
                    }
                }
            }
        }

        if (leftBottom < 64) {

            if ($($("#board").children()[leftBottom]).hasClass("blackBackground") && $($($("#board").children()[leftBottom]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftBottom]).children().length != 0) {
                var id = leftBottom - Math.sqrt($("#board").children().length) - 1;
                console.log('LeftBottomId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

                        MultipleMoves(id);
                    }
                }
            }
        }

        if (rightUpper < 64) {

            if ($($("#board").children()[rightUpper]).hasClass("blackBackground") && $($($("#board").children()[rightUpper]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightUpper]).children().length != 0) {
                var id = rightUpper + Math.sqrt($("#board").children().length) + 1;
                console.log('RightUpperId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

                        MultipleMoves(id);
                    }
                }
            }
        }

        if (rightBottom < 64) {
            console.log('RightBottom: ' + rightBottom);
            console.log($($($("#board").children()[rightBottom]).children()).hasClass(checkerClass) == false);
            if ($($("#board").children()[rightBottom]).hasClass("blackBackground") && $($($("#board").children()[rightBottom]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightBottom]).children().length != 0) {
                var id = rightBottom - Math.sqrt($("#board").children().length) + 1;
                console.log('RightBottomId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(checkerClass) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

                        MultipleMoves(id);
                    }
                }
            }
        }
    }
}

function GetCheckerJson(data) {
    console.log(data);
    var json = JSON.stringify(data);
    checkersList = JSON.parse(json);
    length = checkersList.length;
    console.log(checkersList);

    var idClickedChecker;

    var id = 0;

    if (length == 12) {
        for (var row = 0; row < 8; row++) {
            if (row % 2 == 0) {
                for (var line = 0; line < 8; line++) {
                    var div = document.createElement("div");
                    $(div).attr("id", id);
                    if (line % 2 == 0) {
                        $(div).addClass("boardSquare blackBackground")
                    }
                    else {
                        $(div).addClass("boardSquare whiteBackground")
                    }
                    $("#board").append(div);
                    id++;
                }
            }
            else {
                for (var line = 0; line < 8; line++) {
                    var div = document.createElement("div");
                    $(div).attr("id", id);
                    if (line % 2 == 0) {
                        $(div).addClass("boardSquare whiteBackground")
                    }
                    else {
                        $(div).addClass("boardSquare blackBackground")
                    }
                    $("#board").append(div);
                    id++;
                }
            }
        }

        Checkers();


    }

    $($("#board").children()).click(function () {
        if ($(this).children().length != 0) {
            idClickedChecker = $(this).attr("id");
            $($("#board").children()).removeClass("possibleMove");

            var skip = 0;

            var idLeftUpper = parseInt($(this).attr("id")) + Math.sqrt($("#board").children().length) - 1;
            var idLeftBottom = parseInt($(this).attr("id")) - Math.sqrt($("#board").children().length) - 1;
            var idRightUpper = parseInt($(this).attr("id")) + Math.sqrt($("#board").children().length) + 1;
            var idRightBottom = parseInt($(this).attr("id")) - Math.sqrt($("#board").children().length) + 1;

            console.log('\nLeft: ' + idLeftUpper);
            console.log('Right: ' + idRightUpper);

            if ($($(this).children()).hasClass("blackCheckers")) {
                if (skip == 0) {
                    if (
                    ($($("#board").children()[idLeftUpper]).hasClass("blackBackground") && $($($("#board").children()[idLeftUpper]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idLeftUpper]).children().length != 0)

                    || ($($("#board").children()[idLeftBottom]).hasClass("blackBackground") && $($($("#board").children()[idLeftBottom]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idLeftBottom]).children().length != 0)

                    || ($($("#board").children()[idRightUpper]).hasClass("blackBackground") && $($($("#board").children()[idRightUpper]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idRightUpper]).children().length != 0)

                    || ($($("#board").children()[idRightBottom]).hasClass("blackBackground") && $($($("#board").children()[idRightBottom]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idRightBottom]).children().length != 0)) {

                        MultipleMoves(parseInt($(this).attr("id")), "blackCheckers");
                        skip++;
                    }

                    else {
                        if ($($("#board").children()[idLeftUpper]).children().length == 0 && $($("#board").children()[idLeftUpper]).hasClass("blackBackground")) {
                            $($("#board").children()[idLeftUpper]).addClass("possibleMove");
                            skip = 0;
                        }
                        if ($($("#board").children()[idRightUpper]).children().length == 0 && $($("#board").children()[idRightUpper]).hasClass("blackBackground")) {
                            $($("#board").children()[idRightUpper]).addClass("possibleMove");
                            skip = 0;
                        }
                    }
                }
            }
            else {
                if (skip == 0) {
                    if (
                    ($($("#board").children()[idLeftUpper]).hasClass("blackBackground") && $($($("#board").children()[idLeftUpper]).children()).hasClass("whiteBackground") == false && $($("#board").children()[idLeftUpper]).children().length != 0)

                    || ($($("#board").children()[idLeftBottom]).hasClass("blackBackground") && $($($("#board").children()[idLeftBottom]).children()).hasClass("whiteBackground") == false && $($("#board").children()[idLeftBottom]).children().length != 0)

                    || ($($("#board").children()[idRightUpper]).hasClass("blackBackground") && $($($("#board").children()[idRightUpper]).children()).hasClass("whiteBackground") == false && $($("#board").children()[idRightUpper]).children().length != 0)

                    || ($($("#board").children()[idRightBottom]).hasClass("blackBackground") && $($($("#board").children()[idRightBottom]).children()).hasClass("whiteBackground") == false && $($("#board").children()[idRightBottom]).children().length != 0)) {

                        MultipleMoves(parseInt($(this).attr("id")), "whiteBackground");
                        skip++;
                    }

                    else {
                        if ($($("#board").children()[idLeftBottom]).children().length == 0 && $($("#board").children()[idLeftBottom]).hasClass("blackBackground")) {
                            $($("#board").children()[idLeftBottom]).addClass("possibleMove");
                            skip = 0;
                        }
                        if ($($("#board").children()[idRightBottom]).children().length == 0 && $($("#board").children()[idRightBottom]).hasClass("blackBackground")) {
                            $($("#board").children()[idRightBottom]).addClass("possibleMove");
                            skip = 0;
                        }
                    }
                }
            }
        }
        else {
            if ($(this).hasClass("possibleMove")) {
                console.log(skip);
                if ($($(this).children()).hasClass("blackCheckers")) {
                    $($("#board").children()[idClickedChecker]).children().remove();

                    var div = document.createElement("div");
                    $(div).addClass("checkerCircle blackCheckers");
                    $(this).removeClass("possibleMove");
                    $(this).append(div);
                    skip = 0;

                    if ($(this).attr("id") >= 56 && $(this).attr("id") < 64)
                        IsQueen = true;
                    else
                        IsQueen = false;

                    $($("#board").children()).removeClass("possibleMove");
                }
                else {
                    $($("#board").children()[idClickedChecker]).children().remove();

                    var div = document.createElement("div");
                    $(div).addClass("checkerCircle whiteBackground");
                    $(this).removeClass("possibleMove");
                    $(this).append(div);
                    skip = 0;

                    if ($(this).attr("id") >= 56 && $(this).attr("id") < 64)
                        IsQueen = true;
                    else
                        IsQueen = false;

                    $($("#board").children()).removeClass("possibleMove");
                }
                //PostInfoChecker(idClickedChecker, $(this).attr("id"), IsQueen, false);
            }
        }
    })

    $($("#board").children()).dblclick(function () {
        if ($(this).hasClass("posibbleMove") == false)
        {
            $($("#board").children()).removeClass("possibleMove");
            skip = 0;
        }
        else {
            var idCheck = $($($("#board").children()[idClickedChecker]).children[0]).attr("id");
            $($("#board").children()[idClickedChecker]).children().remove();

            var div = document.createElement("div");
            $(div).addClass("checkerCircle blackCheckers");
            $(this).removeClass("possibleMove");
            $(this).append(div);
            skip = 0;

            if ($(this).attr("id") >= 56 && $(this).attr("id") < 64)
                IsQueen = true;
            else
                IsQueen = false;

            $($("#board").children()).removeClass("possibleMove");
            PostInfoChecker(idCheck, $(this).attr("id"), IsQueen, false);
        }
    })
}

function GameInfoJson(data) {
    console.log(data);
    var json = JSON.stringify(data);
    game = JSON.parse(json);
    console.log(game);
}

function PostInfoChecker(previousPosition, currentPosition, isQueen, isEaten) {
    var checkerId = checkersList["11"].ColorId;
    var json = { GameId: game.Id, ColorId: checkerId, IsQueen: isQueen, IsEaten: isEaten, Movement: new Date(), Position: currentPosition, PrevPosition: previousPosition };
    $.ajax({
        url: "/Game/AddCheckers",
        type: 'POST',   
        datatype: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(json),
        success: function(data) {}
    })
}