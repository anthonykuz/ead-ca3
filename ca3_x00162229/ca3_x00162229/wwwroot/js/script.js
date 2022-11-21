
document.querySelector('body').addEventListener('click', function (event) {
    
});

let touchFact = function (event) {
    if (event.target.className === 'fact-collapsed') {
        event.target.classList.remove('fact-collapsed');
        event.target.classList.add('fact');

    } else if (event.target.className === 'fact') {
        event.target.classList.add('fact-collapsed');
        event.target.classList.remove('fact');
    }

    else if (event.target.parentElement.className === 'fact-collapsed') {
        event.target.parentElement.classList.remove('fact-collapsed');
        event.target.parentElement.classList.add('fact');
    } else if (event.target.parentElement.className === 'fact') {
        event.target.parentElement.classList.add('fact-collapsed');
        event.target.parentElement.classList.remove('fact');
    }
}