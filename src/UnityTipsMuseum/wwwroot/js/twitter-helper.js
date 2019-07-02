// https://developer.twitter.com/en/docs/twitter-for-websites/embedded-tweets/guides/embedded-tweet-javascript-factory-function
function createTweet(id) {    
    twttr.widgets.createTweet(
        id, 
        document.getElementById('tweetId_' + id),
        {
            width: 250
        });

    return true;
}

function removeAllTweets() {    
    var elements = document.getElementsByClassName('twitter-tweet');
  
    while(elements.length > 0) {
        elements[0].parentNode.removeChild(elements[0]);
    }

    return true;
}