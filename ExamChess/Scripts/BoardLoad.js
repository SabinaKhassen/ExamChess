

var game;

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

    for (var i = 0; i < $("#board").children().length / 2 - Math.sqrt($("#board").children().length) ; i++) {
        if ($($("#board").children()[i]).hasClass("blackBackground")) {
            var div = document.createElement("div");
            $(div).addClass("checkerCircle blackCheckers")
            $("#board").children()[i].append(div);
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

function MultipleMoves(checkerId) {

    console.log('\nIn');

    if (checkerId < 64) {

        var leftUpper = checkerId + Math.sqrt($("#board").children().length) - 1;
        var leftBottom = checkerId - Math.sqrt($("#board").children().length) - 1;
        var rightUpper = checkerId + Math.sqrt($("#board").children().length) + 1;
        var rightBottom = checkerId - Math.sqrt($("#board").children().length) + 1;

        console.log('\nCheckerId: ' + checkerId);

        if (leftUpper < 64) {

            if ($($("#board").children()[leftUpper]).hasClass("blackBackground") && $($($("#board").children()[leftUpper]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftUpper]).children().length != 0) {
                var id = leftUpper + Math.sqrt($("#board").children().length) - 1;
                console.log('LeftUpperId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

                        MultipleMoves(id);
                    }
                }
            }
        }

        if (leftBottom < 64) {

            if ($($("#board").children()[leftBottom]).hasClass("blackBackground") && $($($("#board").children()[leftBottom]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftBottom]).children().length != 0) {
                var id = leftBottom - Math.sqrt($("#board").children().length) - 1;
                console.log('LeftBottomId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

                        MultipleMoves(id);
                    }
                }
            }
        }

        if (rightUpper < 64) {

            if ($($("#board").children()[rightUpper]).hasClass("blackBackground") && $($($("#board").children()[rightUpper]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightUpper]).children().length != 0) {
                var id = rightUpper + Math.sqrt($("#board").children().length) + 1;
                console.log('RightUpperId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

                        MultipleMoves(id);
                    }
                }
            }
        }

        if (rightBottom < 64) {
            console.log('RightBottom: ' + rightBottom);
            console.log($($($("#board").children()[rightBottom]).children()).hasClass("blackCheckers") == false);
            if ($($("#board").children()[rightBottom]).hasClass("blackBackground") && $($($("#board").children()[rightBottom]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightBottom]).children().length != 0) {
                var id = rightBottom - Math.sqrt($("#board").children().length) + 1;
                console.log('RightBottomId: ' + id);
                if (id < 64 && $($("#board").children()[id]).hasClass("possibleMove") == false && $($("#board").children()[id]).hasClass("blackBackground") && $($("#board").children()[id]).children().length == 0) {
                    $($("#board").children()[id]).addClass("possibleMove");

                    var leftUpperId = id + Math.sqrt($("#board").children().length) - 1;
                    var leftBottomId = id - Math.sqrt($("#board").children().length) - 1;
                    var rightUpperId = id + Math.sqrt($("#board").children().length) + 1;
                    var rightBottomId = id - Math.sqrt($("#board").children().length) + 1;

                    if (($($("#board").children()[leftUpperId]).hasClass("blackBackground") && $($($("#board").children()[leftUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftUpperId]).children().length != 0)

                    || ($($("#board").children()[leftBottomId]).hasClass("blackBackground") && $($($("#board").children()[leftBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[leftBottomId]).children().length != 0)

                    || ($($("#board").children()[rightUpperId]).hasClass("blackBackground") && $($($("#board").children()[rightUpperId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightUpperId]).children().length != 0)

                    || ($($("#board").children()[rightBottomId]).hasClass("blackBackground") && $($($("#board").children()[rightBottomId]).children()).hasClass("blackCheckers") == false && $($("#board").children()[rightBottomId]).children().length != 0)) {

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
    var obj = JSON.parse(json);
    length = obj.length;

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

            if (skip == 0) {
                if (
                ($($("#board").children()[idLeftUpper]).hasClass("blackBackground") && $($($("#board").children()[idLeftUpper]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idLeftUpper]).children().length != 0)

                || ($($("#board").children()[idLeftBottom]).hasClass("blackBackground") && $($($("#board").children()[idLeftBottom]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idLeftBottom]).children().length != 0)

                || ($($("#board").children()[idRightUpper]).hasClass("blackBackground") && $($($("#board").children()[idRightUpper]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idRightUpper]).children().length != 0)

                || ($($("#board").children()[idRightBottom]).hasClass("blackBackground") && $($($("#board").children()[idRightBottom]).children()).hasClass("blackCheckers") == false && $($("#board").children()[idRightBottom]).children().length != 0)) {

                    MultipleMoves(parseInt($(this).attr("id")));
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
            if ($(this).hasClass("possibleMove")) {
                $($("#board").children()[idClickedChecker]).children().remove();

                var div = document.createElement("div");
                $(div).addClass("checkerCircle blackCheckers");
                $(this).removeClass("possibleMove");
                $(this).append(div);


            }
        }
    })

    $($("#board").children()).dblclick(function () {
        $($("#board").children()).removeClass("possibleMove");
        skip = 0;
    })
}

function GameInfoJson(data) {
    console.log(data);
    var json = JSON.stringify(data);
    game = JSON.parse(json);
    console.log(object);
}

function PostInfoChecker(previousPosition, currentPosition) {
    $.ajax({
        url: 
    })
}