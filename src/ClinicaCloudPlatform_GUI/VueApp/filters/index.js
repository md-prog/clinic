const urlParser = document.createElement('a')

export function domain (url) {
    urlParser.href = url
    return urlParser.hostname
}

export function count (arr) {
    return arr.length
}

export function prettyDate (date) {
    var a = new Date(date)
    if(isNaN(a.getTime()))
        return '';
    return a.toDateString()
}

export function MMDDYYYY (date) {
    var a = new Date(date);
    if(isNaN(a.getTime()))
        return '';
    return a.getDay() + '/' + a.getMonth() + '/' + a.getFullYear();
}

export function MMDDYYYYhhmm (date) {
    var a = new Date(date);
    if(isNaN(a.getTime()))
        return '';
    return (a.getMonth()+1) + '/' + a.getDate() + '/' + a.getFullYear() 
        + ' ' + ("00" + a.getHours()).slice(2) + ':' + ("00" + a.getMinutes()).slice(2);
}

export function localeDate (date) {
    var a = new Date(date);
    if(isNaN(a.getTime()))
        return '';
    return a.toLocaleString();
}

export function pluralize (time, label) {
    if (time === 1) {
        return time + label
    }

    return time + label + 's'
}

export function truncate (string)
{
    return string.substring(0, 24) + '...';
}
