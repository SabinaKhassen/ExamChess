var game;
var skip = 0;
var skipArray = new Array();
var redSkips = new Array();

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
    for (var i = 0; i < $("#board").children().length / 2 - Math.sqrt($("#board").children().length); i++) {
        if ($($("#board").children()[i]).hasClass("blackBackground")) {
            var div = document.createElement("div");
            $(div).addClass("checkerCircle blackCheckers")
            $("#board").children()[i].append(div);
        }
    }

    for (var i = $("#board").children().length - 1; i > $("#board").children().length / 2 + Math.sqrt($("#board").children().length); i--) {
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

function MultipleMoves(checkerId, classChecker, checkerOne, checkerTwo, prevChecker) {
    if (checkerId < 64) {

        var leftUpper = parseInt(checkerId) + Math.sqrt($("#board").children().length) - 1;
        var leftBottom = checkerId - Math.sqrt($("#board").children().length) - 1;
        var rightUpper = parseInt(checkerId) + Math.sqrt($("#board").children().length) + 1;
        var rightBottom = checkerId - Math.sqrt($("#board").children().length) + 1;


        if (rightUpper < 56) {

            if ($($("#board").children()[rightUpper]).hasClass("blackBackground") && $($($("#board").children()[rightUpper]).children()).hasClass(classChecker) == false && $($("#board").children()[rightUpper]).children().length != 0) {
                var id = rightUpper + Math.sqrt($("#board").children().length) + 1;
                if (id < 64 && id != prevChecker && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                        || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                        || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                        || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {
                        skip++;
                        skipArray.push(rightUpper);
                        redSkips.push(id);
                        MultipleMoves(id, classChecker, checkerOne, checkerTwo, checkerId);
                    }
                }
            }
        }
        else {
            if ($($($("#board").children()[rightUpper]).children()).hasClass(checkerOne)) {
                if ($($("#board").children()[leftBottom]).children().length == 0 && $($("#board").children()[leftBottom]).hasClass("blackBackground")) {
                    $($("#board").children()[leftBottom]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
                if ($($("#board").children()[rightBottom]).children().length == 0 && $($("#board").children()[rightBottom]).hasClass("blackBackground")) {
                    $($("#board").children()[rightBottom]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
            }
        }


        if (rightBottom < 64 && rightBottom > 7) {
            if ($($("#board").children()[rightBottom]).hasClass("blackBackground") && $($($("#board").children()[rightBottom]).children()).hasClass(classChecker) == false && $($("#board").children()[rightBottom]).children().length != 0) {
                var id = rightBottom - Math.sqrt($("#board").children().length) + 1;
                if (id < 64 && id != prevChecker && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                        || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                        || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                        || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {
                        skip++;
                        skipArray.push(rightBottom);
                        redSkips.push(id);
                        MultipleMoves(id, classChecker, checkerOne, checkerTwo, checkerId);
                    }
                }
            }
        }
        else {
            if ($($($("#board").children()[rightBottom]).children()).hasClass(checkerTwo)) {
                if ($($("#board").children()[leftUpper]).children().length == 0 && $($("#board").children()[leftUpper]).hasClass("blackBackground")) {
                    $($("#board").children()[leftUpper]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
                if ($($("#board").children()[rightUpper]).children().length == 0 && $($("#board").children()[rightUpper]).hasClass("blackBackground")) {
                    $($("#board").children()[rightUpper]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
            }
        }


        if (leftBottom < 64 && leftBottom > 7) {

            if ($($("#board").children()[leftBottom]).hasClass("blackBackground") && $($($("#board").children()[leftBottom]).children()).hasClass(classChecker) == false && $($("#board").children()[leftBottom]).children().length != 0) {

                var id = leftBottom - Math.sqrt($("#board").children().length) - 1;
                if (id < 64 && id != prevChecker && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                        || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                        || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                        || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {
                        skip++;
                        skipArray.push(leftBottom);
                        redSkips.push(id);
                        MultipleMoves(id, classChecker, checkerOne, checkerTwo, checkerId);
                    }
                }
            }
        }
        else {
            if ($($($("#board").children()[leftBottom]).children()).hasClass(checkerTwo)) {
                if ($($("#board").children()[leftUpper]).children().length == 0 && $($("#board").children()[leftUpper]).hasClass("blackBackground")) {
                    $($("#board").children()[leftUpper]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
                if ($($("#board").children()[rightUpper]).children().length == 0 && $($("#board").children()[rightUpper]).hasClass("blackBackground")) {
                    $($("#board").children()[rightUpper]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
            }
        }


        if (leftUpper < 56) {

            if ($($("#board").children()[leftUpper]).hasClass("blackBackground") && $($($("#board").children()[leftUpper]).children()).hasClass(classChecker) == false && $($("#board").children()[leftUpper]).children().length != 0) {
                var id = leftUpper + Math.sqrt($("#board").children().length) - 1;
                if (id < 64 && id != prevChecker && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftUpperId]).children().length != 0)

                        || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[leftBottomId]).children().length != 0)

                        || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightUpperId]).children().length != 0)

                        || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass(classChecker) == false && $($("#board").children()[rightBottomId]).children().length != 0)) {
                        skip++;
                        skipArray.push(leftUpper);
                        redSkips.push(id);
                        MultipleMoves(id, classChecker, checkerOne, checkerTwo, checkerId);
                    }
                }
            }
        }
        else {
            if ($($($("#board").children()[leftUpper]).children()).hasClass(checkerOne)) {
                if ($($("#board").children()[leftBottom]).children().length == 0 && $($("#board").children()[leftBottom]).hasClass("blackBackground")) {
                    $($("#board").children()[leftBottom]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
                if ($($("#board").children()[rightBottom]).children().length == 0 && $($("#board").children()[rightBottom]).hasClass("blackBackground")) {
                    $($("#board").children()[rightBottom]).addClass("possibleMove");
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                }
            }
        }

    }
}

function Eat(checkerId, classChecker, newPosition) {
    var check = 0;
    console.log('\nEat id: ' + checkerId);
    console.log('Skip: ' + skip);
    console.log('Skip array: ' + skipArray);
    for (var i = 0; i < redSkips.length; i++) {
        var leftUpper = parseInt(redSkips[i]) + Math.sqrt($("#board").children().length) - 1 + Math.sqrt($("#board").children().length) - 1;
        var leftBottom = redSkips[i] - Math.sqrt($("#board").children().length) - 1 - Math.sqrt($("#board").children().length) - 1;
        var rightUpper = parseInt(redSkips[i]) + Math.sqrt($("#board").children().length) + 1 + Math.sqrt($("#board").children().length) + 1;
        var rightBottom = redSkips[i] - Math.sqrt($("#board").children().length) + 1 - Math.sqrt($("#board").children().length) + 1;
        if (redSkips[i + 1] == leftUpper || redSkips[i + 1] == leftBottom || redSkips[i + 1] == rightUpper || redSkips[i + 1] == rightBottom) {
            if (newPosition == redSkips[i]) {
                check = redSkips[i + 1];
                break;
            }
        }
    }
    for (var i = 0; i < skipArray.length; i++) {
        if (redSkips[i] != check) {
            if (i == 0) {
                var leftUpper = parseInt(checkerId) + Math.sqrt($("#board").children().length) - 1;
                var leftBottom = checkerId - Math.sqrt($("#board").children().length) - 1;
                var rightUpper = parseInt(checkerId) + Math.sqrt($("#board").children().length) + 1;
                var rightBottom = checkerId - Math.sqrt($("#board").children().length) + 1;
            }
            else {
                var leftUpper = parseInt(redSkips[i - 1]) + Math.sqrt($("#board").children().length) - 1;
                var leftBottom = redSkips[i - 1] - Math.sqrt($("#board").children().length) - 1;
                var rightUpper = parseInt(redSkips[i - 1]) + Math.sqrt($("#board").children().length) + 1;
                var rightBottom = redSkips[i - 1] - Math.sqrt($("#board").children().length) + 1;
            }

            if (skipArray[i] == leftUpper || skipArray[i] == leftBottom || skipArray[i] == rightUpper || skipArray[i] == rightBottom) {
                $($("#board").children()[newPosition]).removeClass("possibleMove");
                $($("#board").children()[skipArray[i]]).children().remove();
                skip--;
            }
        }
        else
            break;
    }

    skipArray = new Array();
    redSkips = new Array();
}

function GetCheckerJson() {
    console.log("GetCheckerJson");

    var idClickedChecker;

    var id = 0;

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

                        MultipleMoves(parseInt($(this).attr("id")), "blackCheckers", "blackCheckers", "whiteBackground", 1);
                    }

                    else {
                        if ($($("#board").children()[idLeftUpper]).children().length == 0 && $($("#board").children()[idLeftUpper]).hasClass("blackBackground")) {
                            $($("#board").children()[idLeftUpper]).addClass("possibleMove");
                            skip = 0;
                            skipArray = new Array();
                            redSkips = new Array();
                        }
                        if ($($("#board").children()[idRightUpper]).children().length == 0 && $($("#board").children()[idRightUpper]).hasClass("blackBackground")) {
                            $($("#board").children()[idRightUpper]).addClass("possibleMove");
                            skip = 0;
                            skipArray = new Array();
                            redSkips = new Array();
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

                        MultipleMoves(parseInt($(this).attr("id")), "whiteBackground", "whiteBackground", "blackCheckers", 1);
                    }

                    else {
                        if ($($("#board").children()[idLeftBottom]).children().length == 0 && $($("#board").children()[idLeftBottom]).hasClass("blackBackground")) {
                            $($("#board").children()[idLeftBottom]).addClass("possibleMove");
                            skip = 0;
                            skipArray = new Array();
                            redSkips = new Array();
                        }
                        if ($($("#board").children()[idRightBottom]).children().length == 0 && $($("#board").children()[idRightBottom]).hasClass("blackBackground")) {
                            $($("#board").children()[idRightBottom]).addClass("possibleMove");
                            skip = 0;
                            skipArray = new Array();
                            redSkips = new Array();
                        }
                    }
                }
            }
        }
        else {
            if ($(this).hasClass("possibleMove")) {
                console.log('Skip: ' + skip);
                if ($($("#board").children()[idClickedChecker]).children().hasClass("blackCheckers")) {
                    $($("#board").children()[idClickedChecker]).children().remove();

                    var div = document.createElement("div");
                    $(div).addClass("checkerCircle blackCheckers");
                    $(this).removeClass("possibleMove");
                    $(this).append(div);

                    if ($(this).attr("id") >= 56 && $(this).attr("id") < 64)
                        IsQueen = true;
                    else
                        IsQueen = false;

                    Eat(idClickedChecker, "blackCheckers", $(this).attr("id"));
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
                    $($("#board").children()).removeClass("possibleMove");
                }
                else {
                    $($("#board").children()[idClickedChecker]).children().remove();

                    var div = document.createElement("div");
                    $(div).addClass("checkerCircle whiteBackground");
                    $(this).removeClass("possibleMove");
                    $(this).append(div);

                    if ($(this).attr("id") >= 0 && $(this).attr("id") < 8)
                        IsQueen = true;
                    else
                        IsQueen = false;

                    Eat(idClickedChecker, "whiteBackground", $(this).attr("id"));
                    skip = 0;
                    skipArray = new Array();
                    redSkips = new Array();
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
    console.log("GameInfoJson");
    console.log(data);
    var json = JSON.stringify(data);
    game = JSON.parse(json);
    console.log(game);
    GetCheckerJson();
}

//function PostInfoChecker(previousPosition, currentPosition, isQueen, isEaten) {
//    var checkerId = checkersList["11"].ColorId;
//    var json = { GameId: game.Id, ColorId: checkerId, IsQueen: isQueen, IsEaten: isEaten, Movement: new Date(), Position: currentPosition, PrevPosition: previousPosition };
//    $.ajax({
//        url: "/Game/AddCheckers",
//        type: 'POST',   
//        datatype: 'json',
//        contentType: 'application/json; charset=utf-8',
//        data: JSON.stringify(json),
//        success: function(data) {}
//    })
//}