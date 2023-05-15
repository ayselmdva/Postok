$(document).ready(function(){

    $(document).on("click", ".delete-item-book", function (e) {

        e.preventDefault();

        var url2 = $(this).attr("href")

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(url2)
                    .then(res => res.json())
                    .then(data => {
                        if (data.status == 200) {
                            window.location.reload(true)
                        }
                        else {
                            Swal.fire(
                                'Error!',
                                'Your file has not been deleted.',
                                'error'
                            )
                        }
                    })
            }
        })
    })


})