
let touchFact = function (event) {
    // Checks to see if mouse target has either classes
    if (event.target.className === 'fact-collapsed') {
        event.target.classList.remove('fact-collapsed');
        event.target.classList.add('fact');

    } else if (event.target.className === 'fact') {
        event.target.classList.add('fact-collapsed');
        event.target.classList.remove('fact');
    }

    // Checks to see if parent of the mouse target has either classes
    else if (event.target.parentElement.className === 'fact-collapsed') {
        event.target.parentElement.classList.remove('fact-collapsed');
        event.target.parentElement.classList.add('fact');

    } else if (event.target.parentElement.className === 'fact') {
        event.target.parentElement.classList.add('fact-collapsed');
        event.target.parentElement.classList.remove('fact');
    }
}