import React, {useState} from "react";
import './App.css'


const url = 'https://localhost:5443/Person'
//https://localhost:5443/Person?id=

function App() {
    const [id, setId] = useState('')
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [email, setEmail] = useState('')
    const [phone, setPhone] = useState('')
    const [address, setAddress] = useState('')
    const [city, setCity] = useState('')

    const onIdChange = (e) => {
        setId(e.target.value)
    }

    const onFirstNameChange = (e) => {
        setFirstName(e.target.value)
    }
    const onLastNameChange = (e) => {
        setLastName(e.target.value)
    }
    const onEmailChange = (e) => {
        setEmail(e.target.value)
    }
    const onPhoneChange = (e) => {
        setPhone(e.target.value)
    }
    const onAddressChange = (e) => {
        setAddress(e.target.value)
    }
    const onCityChange = (e) => {
        setCity(e.target.value)
    }


    const onSubmit = (e) => {
        e.preventDefault()
        const data = {
            id, firstName, lastName, email, phone, address, city
        }
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        }).catch((error) => {
            console.error('Error:', error);
        });
    }

    const onLoad = (e) => {
        e.preventDefault()

        fetch(`${url}?id=${id}`)
            .then(response => response.json())
            .then(data => {
                const {id, firstName, lastName, email, phone, address, city} = data

                setId(id)
                setFirstName(firstName)
                setLastName(lastName)
                setCity(city)
                setAddress(address)
                setPhone(phone)
                setEmail(email)

            }).catch((error) => {
            console.error('Error:', error);
        });
    }

    return (
        <div className="App">
            <form style={{ display: 'flex', flexDirection: 'column'}}>
                <label>Id:
                    <input type="text" value={id} onChange={onIdChange} />
                </label>
                <label>First name:
                    <input type="text" value={firstName} onChange={onFirstNameChange} />
                </label>
                <label>Last name:
                    <input type="text" value={lastName} onChange={onLastNameChange} />
                </label>
                <label>Email:
                    <input type="email" value={email} onChange={onEmailChange} />
                </label>
                <label>Phone:
                    <input type="phone" value={phone} onChange={onPhoneChange} />
                </label>
                <label>Address:
                    <input type="text" value={address} onChange={onAddressChange} />
                </label>
                <label>City:
                    <input type="text" value={city} onChange={onCityChange} />
                </label>
                <button type='submit' onClick={onSubmit}>Save</button>
                <button type='button' onClick={onLoad}>Load</button>
            </form>
        </div>
    )
}

export default App
