$(document).ready(function() {
    if (document.getElementById("description")) {
        ClassicEditor.create(document.querySelector('#description'),
            {
                toolbar: {
                    items: [
                        'heading',
                        '|',
                        'bold',
                        'italic',
                        'fontSize',
                        'fontColor',
                        'link',
                        'bulletedList',
                        'numberedList',
                        'fontSize',
                        '|',
                        'indent',
                        'outdent',
                        '|',
                        'blockQuote',
                        'insertTable',
                        'undo',
                        'redo',
                        'code'
                    ]
                },
                language: 'fa',
                image: {
                    toolbar: [
                        'imageTextAlternative',
                        'imageStyle:full',
                        'imageStyle:side'
                    ]
                },
                table: {
                    contentToolbar: [
                        'tableColumn',
                        'tableRow',
                        'mergeTableCells'
                    ]
                },
                licenseKey: '',
            }).then(editor => { window.editor = editor; });

    }
    if (document.getElementById("description-2")) {
        ClassicEditor.create(document.querySelector('#description-2'),
            {
                toolbar: {
                    items: [
                        'heading',
                        '|',
                        'bold',
                        'italic',
                        'link',
                        'bulletedList',
                        'numberedList',
                        'fontSize',
                        '|',
                        'indent',
                        'outdent',
                        '|',
                        'blockQuote',
                        'insertTable',
                        'undo',
                        'redo',
                        'code'
                    ]
                },
                language: 'fa',
                image: {
                    toolbar: [
                        'imageTextAlternative',
                        'imageStyle:full',
                        'imageStyle:side'
                    ]
                },
                table: {
                    contentToolbar: [
                        'tableColumn',
                        'tableRow',
                        'mergeTableCells'
                    ]
                },
                licenseKey: '',
            }).then(editor => { window.editor = editor; });

    }
    if (document.getElementById("description-3")) {
        ClassicEditor.create(document.querySelector('#description-3'),
            {
                toolbar: {
                    items: [
                        'heading',
                        '|',
                        'bold',
                        'italic',
                        'link',
                        'bulletedList',
                        'numberedList',
                        'fontSize',
                        '|',
                        'indent',
                        'outdent',
                        '|',
                        'blockQuote',
                        'insertTable',
                        'undo',
                        'redo',
                        'code'
                    ]
                },
                language: 'fa',
                image: {
                    toolbar: [
                        'imageTextAlternative',
                        'imageStyle:full',
                        'imageStyle:side'
                    ]
                },
                table: {
                    contentToolbar: [
                        'tableColumn',
                        'tableRow',
                        'mergeTableCells'
                    ]
                },
                licenseKey: '',
            }).then(editor => { window.editor = editor; });

    }
    if (document.getElementById("full_cheditor")) {
        ClassicEditor
            .create(document.querySelector('#full_cheditor'), {
                simpleUpload: {
                    uploadUrl: '/Upload/Article'
                },
                toolbar: {
                    items: [
                        'heading',
                        'highlight',
                        'removeFormat',
                        '|',
                        'bold',
                        'italic',
                        'underline',
                        'alignment',
                        'link',
                        '|',
                        'bulletedList',
                        'numberedList',
                        'indent',
                        'outdent',
                        '|',
                        'fontBackgroundColor',
                        'fontFamily',
                        'fontColor',
                        'fontSize',
                        '|',
                        'htmlEmbed',
                        'imageUpload',
                        'imageInsert',
                        'mediaEmbed',
                        '|',
                        'blockQuote',
                        'insertTable',
                        'specialCharacters',
                        'horizontalLine',
                        '|',
                        'undo',
                        'redo',
                        '|',
                        'code',
                        'codeBlock',
                        'exportWord'
                    ]
                },
                language: 'fa',
                image: {
                    toolbar: [
                        'imageTextAlternative',
                        'imageStyle:full',
                        'imageStyle:side',
                        'linkImage'
                    ]
                },
                table: {
                    contentToolbar: [
                        'tableColumn',
                        'tableRow',
                        'mergeTableCells',
                        'tableProperties'
                    ]
                },
                licenseKey: '',

            })
            .then(editor => {
                window.editor = editor;
            })
            .catch(error => {
                console.error('Oops, something gone wrong!');
                console.error('Please, report the following error in the https://github.com/ckeditor/ckeditor5 with the build id and the error stack trace:');
                console.warn('Build id: 1hgh63bxm5nk-t1efehf8ocs2');
                console.error(error);
            });
    }
    if (document.getElementById("description_full")) {
        ClassicEditor
            .create(document.querySelector('#description_full'), {
                toolbar: {
                    items: [
                        'heading',
                        'highlight',
                        'removeFormat',
                        '|',
                        'bold',
                        'italic',
                        'underline',
                        'alignment',
                        'link',
                        '|',
                        'bulletedList',
                        'numberedList',
                        'indent',
                        'outdent',
                        '|',
                        'fontBackgroundColor',
                        'fontFamily',
                        'fontColor',
                        'fontSize',
                        '|',
                        'htmlEmbed',
                        'imageUpload',
                        'imageInsert',
                        'mediaEmbed',
                        '|',
                        'blockQuote',
                        'insertTable',
                        'specialCharacters',
                        'horizontalLine',
                        '|',
                        'undo',
                        'redo',
                        '|',
                        'code',
                        'codeBlock',
                        'exportWord'
                    ]
                },
                language: 'fa',
                image: {
                    toolbar: [
                        'imageTextAlternative',
                        'imageStyle:full',
                        'imageStyle:side',
                        'linkImage'
                    ]
                },
                table: {
                    contentToolbar: [
                        'tableColumn',
                        'tableRow',
                        'mergeTableCells',
                        'tableProperties'
                    ]
                },
                licenseKey: '',
                removePlugins: ['Title']
            })
            .then(editor => {
                window.editor = editor;
            })
            .catch(error => {
                console.error('Oops, something gone wrong!');
                console.error('Please, report the following error in the https://github.com/ckeditor/ckeditor5 with the build id and the error stack trace:');
                console.warn('Build id: 1hgh63bxm5nk-t1efehf8ocs2');
                console.error(error);
            });
    }
});