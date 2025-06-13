open System

let rec getNatural () =
    printf "Введите количество элементов списка: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) when n > 0 -> n
    | (true, _) ->
        printfn "Ошибка (число должно быть натуральным)"
        getNatural ()
    | (false, _) ->
        printfn "Ошибка (введено не число)"
        getNatural ()

let rec getFloat num =
    printf "Введите %d-й элемент списка: " num
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) -> n
    | (false, _) ->
        printfn "Ошибка (введено не число)"
        getFloat num

let getOppositeNumbers n =
    let rec loop i list =
        if i > n then
            list
        else
            let number = getFloat i
            loop (i + 1) (list @ [-number])  // Добавляем противоположное число
    loop 1 []

[<EntryPoint>]
let main argv =
    printfn "Программа формирует список противоположных чисел"
    
    let number = getNatural ()
    let oppositeList = getOppositeNumbers number
    
    printfn "Список противоположных чисел: %A" oppositeList
    
    printfn "\nНажмите любую клавишу для выхода..."
    Console.ReadKey() |> ignore
    0