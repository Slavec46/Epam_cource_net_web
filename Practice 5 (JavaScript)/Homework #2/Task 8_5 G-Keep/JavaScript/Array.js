export class Service {
    #mapList = new Map();
    #id = 0;
add(value) {
    if (value === undefined)
        throw new SyntaxError(`value =>| invalid argument value`);

    if (typeof (value) !== 'object')
        throw new SyntaxError(`value =>| not object`);

    this.#mapList.set(this.#id.toString(), value);
    this.#id++;
}

id() {
    return this.#id;
}

show() {
    this.#mapList.forEach((value, key) => {
        console.log(`${key}: ${value}`);
    });;
}

getById(keyString) {
    if (keyString === undefined || keyString === null)
        throw new SyntaxError(`value =>| invalid argument value`);

    if (this.#mapList.has(keyString.toString())) {
        return this.#mapList.get(keyString.toString());
    }

    return null;
}
deleteById(keyString) {
    if (keyString === undefined || keyString === null)
        throw new SyntaxError(`value =>| invalid argument value`);

    if (this.#mapList.has(keyString.toString())) {
        let result = this.#mapList.getById(keyString);
        this.#mapList.delete(keyString.toString());

        return result;
    }

    return null;
}

updateById(keyString, value) {
    if ((keyString === undefined || keyString === null) ||
        (value === undefined))
        throw new SyntaxError(`value =>| invalid argument value`);

    if (typeof (value) !== 'object')
        throw new SyntaxError(`value =>| not object`);

    if (this.#mapList.has(keyString.toString())) {
        let obj = this.getById(keyString);
        obj = Object.assign(obj,value);

        this.replaceById(keyString, obj);
        return true;
    }
    return false;
}

replaceById(keyString, value) {
    if ((keyString === undefined || keyString === null) ||
        (value === undefined))
        throw new SyntaxError(`value =>| invalid argument value`);

    if (typeof (value) !== 'object')
        throw new SyntaxError(`value =>| not object`);

    if (this.#mapList.has(keyString.toString())) {
        this.#mapList.set(keyString.toString(), value);
        return true;
    }
    return false;
}

getAll() {
    return Array.from(this.#mapList.values());
}
}