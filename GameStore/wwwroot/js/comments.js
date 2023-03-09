//Get all comment elements
const comments = document.querySelectorAll('.comment');

//Add listeners to all reply buttons
comments.forEach(comment => {
    const replyButton = comment.querySelector('.reply');

    replyButton.addEventListener('click', (event) => {

        event.preventDefault();

        const allReplySections = document.querySelectorAll('.comment-reply-form');

        allReplySections.forEach(replySection => {
            if (replySection !== replyForm) {
                replySection.style.display = 'none';
            }
        });

        //Hide the reply button
        replyButton.style.display = 'none';

        const replyForm = document.createElement('div');
        replyForm.classList.add('comment-reply-form');

        const formHtml = `
    <form method="post" asp-action="Details" asp-controller="Game" enctype="multipart/form-data">
    <input type="hidden" name="GameId" value="@Model.Game.Id" />
    <input type="hidden" name="PostType" value="reply" />
    <div class="row">
        <div class="col-md-12">
        <textarea placeholder="Your Reply"></textarea>
        </div>
        <div class="col-md-12">
        <button type="submit">Send</button>
        <button type="button" class="cancel-reply">Cancel</button>
        </div>
        
    </div>
    </form>
    `;

        replyForm.innerHTML = formHtml;

        comment.appendChild(replyForm);

        const cancelButton = replyForm.querySelector('.cancel-reply');
        cancelButton.addEventListener('click', (event) => {
            event.preventDefault();
            replyButton.style.display = 'inline-block';
            replyForm.remove();
        });

    });

    //Check the nesting level
    const nestingLevel = comment.querySelectorAll('.comment-reply').length;

    if (nestingLevel >= 3) {
        replyButton.style.display = 'none';
    }
    
});