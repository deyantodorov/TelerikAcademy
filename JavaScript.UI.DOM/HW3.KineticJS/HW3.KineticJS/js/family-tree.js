var familyMembers = [
    {
        mother: 'Maria Petrova',
        father: 'Georgi Petrov',
        children: ['Teodora Petrova', 'Peter Petrov']
    },
    {
        mother: 'Boriana Stamatova',
        father: 'Teodor Stamatov',
        children: ['Martin Stamatov', 'Albena Dimitrova']
    },
    {
        mother: 'Albena Dimitrova',
        father: 'Ivan Dimitrov',
        children: ['Doncho Dimitrov', 'Ivaylo Dimitrov']
    },
    {
        mother: 'Donika Dimitrova',
        father: 'Doncho Dimitrov',
        children: ['Vladimir Dimitrov', 'Iliana Dobreva']
    },
    {
        mother: 'Juliana Petrova',
        father: 'Peter Petrov',
        children: ['Dimitar Petrov', 'Galina Opanova']
    },
    {
        mother: 'Iliana Dobreva',
        father: 'Delian Dobrev',
        children: ['Dimitar Dobrev', 'Galina Pundiova']
    },
    {
        mother: 'Galina Pundiova',
        father: 'Martin Pundiov',
        children: ['Dimitar Pundiov', 'Todor Pundiov']
    },
    {
        mother: 'Maria Pundiova',
        father: 'Dimitar Pundiov',
        children: ['Georgi Pundiov', 'Stoian Pundiov']
    },
    {
        mother: 'Dobrinka Pundiova',
        father: 'Georgi Pundiov',
        children: ['Pavel Pundiov', 'Marian Pundiov']
    },
    {
        mother: 'Elena Pundiova',
        father: 'Marian Pundiov',
        children: ['Kamen Pundiov', 'Hristina Ivancheva']
    },
    {
        mother: 'Petra Stamatova',
        father: 'Todor Stamatov',
        children: ['Teodor Stamatov', 'Boris Opanov', 'Maria Petrova']
    },
    {
        mother: 'Hristina Ivancheva',
        father: 'Martin Ivanchev',
        children: ['Kamen Ivanchev', 'Evgeny Ivanchev']
    },
    {
        mother: 'Maria Ivancheva',
        father: 'Kamen Ivanchev',
        children: ['Ivo Ivanchev', 'Delian Ivanchev']
    },
    {
        mother: 'Nadejda Ivancheva',
        father: 'Ivo Ivanchev',
        children: ['Petio Ivanchev', 'Marin Ivanchev']
    },
    {
        mother: 'Natalia Ivancheva',
        father: 'Delian Ivanchev',
        children: ['Galina Hristova']
    },
    {
        mother: 'Galina Opanova',
        father: 'Boian Opanov',
        children: ['Maria Opanova', 'Patar Opanov']
    },
    {
        mother: 'Galina Hristova',
        father: 'Marin Hristov',
        children: ['Petar Hristov', 'Kamen Hristov', 'Ivan Hristov']
    },
    {
        mother: 'Simona Hristova',
        father: 'Kamen Hristov',
        children: ['Elena Hristova', 'Valeria Hristova']
    }
];

function AddLevelAndIndex() {

    var memberIndex,
        memberLength,
        familyMember,
        familyMemberLength;

    // Add the new properties
    for (memberIndex = 0, memberLength = familyMembers.length; memberIndex < memberLength; memberIndex += 1) {
        familyMembers[memberIndex].level = 0;
        familyMembers[memberIndex].childrenIndex = [];
    }

    // fill them with values
    for (memberIndex = 0, memberLength = familyMembers.length; memberIndex < memberLength; memberIndex += 1) {

        for (familyMember = 0, familyMemberLength = familyMembers.length; familyMember < familyMemberLength; familyMember += 1) {

            var mother = familyMembers[familyMember].children.indexOf(familyMembers[memberIndex].mother),
                father = familyMembers[familyMember].children.indexOf(familyMembers[memberIndex].father);

            if (mother !== -1 || father !== -1) {

                familyMembers[familyMember].childrenIndex.push(memberIndex);
                familyMembers[memberIndex].level = familyMembers[familyMember].level + 1;

                if (familyMembers[memberIndex].childrenIndex.length !== 0) {

                    for (var childIndex in familyMembers[memberIndex].childrenIndex) {

                        increaseLevels(familyMembers[familyMembers[memberIndex].childrenIndex[childIndex]]);
                    }
                }
            }
        }
    }
}

function increaseLevels(family) {

    family.level++;

    if (family.indexWithChildren.length === 0) {
        return;
    }

    for (var childIndex in family.indexWithChildren) {
        increaseLevels(family[family.indexWithChildrens[childIndex]]);
    }
}

function Draw() {
    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1800,
        height: 2000,
    }),
    layer = new Kinetic.Layer(),
    familyTree = [];

    // Fill the array familyTree with rectangles and texts
    makeTree(familyTree);

    // Print the array familyTree
    printTree(familyTree, layer);

    stage.add(layer);
}

function makeTree(familyTree) {
    var countOfMembersInLevel = new Array(20).join('0').split('').map(parseFloat),
        parentsWithHeirs = [],
        memberIndex,
        memberLength,
        parentIndex,
        childrenIndex,
        childrendLength,
        corner,
        text;


    // First we add all members with Hairs
    for (memberIndex = 0, memberLength = familyMembers.length; memberIndex < memberLength; memberIndex += 1) {

        countOfMembersInLevel[familyMembers[memberIndex].level] = parseInt(countOfMembersInLevel[familyMembers[memberIndex].level] + 2);

        for (parentIndex = 0; parentIndex < 2; parentIndex += 1) {

            if (parentIndex === 0) {
                corner = 15;
                text = familyMembers[memberIndex]['mother'];
            }
            else {
                corner = 5;
                text = familyMembers[memberIndex]['father'];
            }

            parentsWithHeirs.push(text);

            familyTree.push(new Kinetic.Rect({
                x: (parentIndex + countOfMembersInLevel[familyMembers[memberIndex].level] - 2) * 160,
                y: familyMembers[memberIndex].level * 120,
                width: 150,
                height: 40,
                stroke: (parentIndex === 0) ? 'purple' : 'blue',
                cornerRadius: corner
            }));

            familyTree.push(new Kinetic.Text({
                x: (parentIndex + countOfMembersInLevel[familyMembers[memberIndex].level] - 2) * 160 + 30,
                y: familyMembers[memberIndex].level * 120 + 13,
                text: text,
                fontFamily: 'Calibri',
                fill: 'black',
            }));
        }
    }

    // In this momment in array parentsWithHeirs we have all with childrens. But there are some members without
    // childrens and we add them now:

    parentsWithHeirs.sort();

    for (memberIndex = 0, memberLength = familyMembers.length; memberIndex < memberLength; memberIndex += 1) {

        for (childrenIndex = 0, childrendLength = familyMembers[memberIndex].children.length; childrenIndex < childrendLength; childrenIndex += 1) {

            if (parentsWithHeirs.indexOf(familyMembers[memberIndex].children[childrenIndex]) === -1) {

                text = familyMembers[memberIndex].children[childrenIndex];

                if (isNaN(countOfMembersInLevel[familyMembers[memberIndex].level + 1])) {
                    countOfMembersInLevel[familyMembers[memberIndex].level + 1] = 0;
                }

                if (text[text.length - 1] === 'а') {
                    corner = 15;
                }
                else {
                    corner = 5;
                }

                familyTree.push(new Kinetic.Rect({
                    x: (countOfMembersInLevel[familyMembers[memberIndex].level + 1]) * 160,
                    y: (familyMembers[memberIndex].level + 1) * 120,
                    width: 150,
                    height: 40,
                    stroke: 'orange',
                    cornerRadius: corner
                }));

                familyTree.push(new Kinetic.Text({
                    x: (countOfMembersInLevel[familyMembers[memberIndex].level + 1]) * 160 + 30,
                    y: (familyMembers[memberIndex].level + 1) * 120 + 13,
                    text: text,
                    fontFamily: 'Calibri',
                    fill: 'black',
                }));

                countOfMembersInLevel[familyMembers[memberIndex].level + 1] += 1;
            }
        }
    }
}

function printTree(familyTree, layer) {
    var familyIndex,
        familyLength;

    for (familyIndex = 0, familyLength = familyTree.length; familyIndex < familyLength; familyIndex += 1) {

        if (familyTree[familyIndex].textArr) {
            var startX = familyTree[familyIndex].getX() + 35,
                startY = familyTree[familyIndex].getY() + 27,
                parent = familyTree[familyIndex].textArr[0].text,
                index = findElement(parent),
                membersIndex,
                membersLength,
                membersFamilyIndex,
                membersFamilyLength;

            if (index !== undefined) {

                for (membersIndex = 0, membersLength = familyMembers[index].children.length; membersIndex < membersLength; membersIndex += 1) {

                    var child = familyMembers[index].children[membersIndex];

                    for (membersFamilyIndex = 0, membersFamilyLength = familyTree.length; membersFamilyIndex < membersFamilyLength; membersFamilyIndex += 1) {

                        if (familyTree[membersFamilyIndex].textArr) {

                            if (familyTree[membersFamilyIndex].textArr[0].text === child) {

                                var endX = familyTree[membersFamilyIndex].getX() + 35,
                                    endY = familyTree[membersFamilyIndex].getY() - 13;

                                layer.add(new Kinetic.Line({
                                    points: [startX, startY, endX, endY],
                                    stroke: 'lightgrey',
                                }));
                            }
                        }
                    }
                }
            }
        }

        layer.add(familyTree[familyIndex]);
    }
}

function findElement(name) {

    for (var i = 0; i < familyMembers.length; i++) {

        if (familyMembers[i].mother === name || familyMembers[i].father === name) {
            return i;
        }
    }
}

window.onload = function () {
    AddLevelAndIndex();
    Draw();
};