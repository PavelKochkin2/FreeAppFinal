import React, { Component } from 'react';
import axios from 'axios';
import { Table, Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label, FormGroup } from 'reactstrap';
import NewFreeItemModal from './Components/newFreeItemModal';
import EditFreeItemModal from './Components/editFreeItemModal';
import FreeItemNavbar from './Components/Navbar';
import ViewPhotoModal from './Components/viewPhotoModal';

export default class App extends Component {

   state = {
        freeItems: [],
        newFreeItemData: {
            name: '',
            description: '',
            photo: ''
        },
        editFreeItemData: {
            id: '',
            name: '',
            description: ''
        },
        viewPhotoData: {
            photo: ''
        },
        newFreeItemModal: false,
        editFreeItemModal: false,
        viewPhotoModal: false
    }

    componentWillMount() {
        this._refreshFreeItems();
    }

    toggleNewFreeItemModal() {
        this.setState({
            newFreeItemModal: !this.state.newFreeItemModal
        });
    }

    addFreeItem() {
        axios.post(window.location.href + 'api/freeitems', this.state.newFreeItemData).then((response) => {
            let { freeItems } = this.state;

            freeItems.push(response.data);

            this.setState({
                freeItems, newFreeItemModal: false, newFreeItemData: {
                    name: '',
                    description: ''
                }
            });
        });
    }

    editFreeItem(id, name, description) {
        this.setState({
            editFreeItemData: { id, name, description },
            editFreeItemModal: !this.state.editFreeItemModal
        });
    }

    toggleEditFreeItemModal() {
        this.setState({
            editFreeItemModal: !this.state.editFreeItemModal
        });
    }

    updateFreeItem() {
        let { name, description } = this.state.editFreeItemData;

        axios.put(window.location.href + 'api/freeitems/' + this.state.editFreeItemData.id,
            {
                name, description
            }).then((response) => {
                this._refreshFreeItems();
                this.setState({
                    editFreeItemModal: false, editFreeItemData: {
                        id: '',
                        name: '',
                        description: ''
                    }
                })
            })
    }

    _refreshFreeItems() {
        axios.get(window.location.href + 'api/freeitems').then((response) => {
            this.setState({
                freeItems: response.data
            });
        });
    }

    deleteFreeItem(id) {
        axios.delete(window.location.href + 'api/freeitems/' + id).then((response) => {
            this._refreshFreeItems();
        });
    }

    toggleViewPhoto(photo) {
        console.log(photo);
        this.setState({
            viewPhotoModal: !this.state.viewPhotoModal,
            viewPhotoData: photo
        });
    }

    render() {

        const appComponent = this;

        let styles = {
            width: '100px',
            height: '100px'
        };



        let freeItems = this.state.freeItems.map((freeItem) => {
            return (
                <tr key={freeItem.id}>
                    <td>{freeItem.id}</td>
                    <td>{freeItem.name}</td>
                    <td>{freeItem.description}</td>
                    <td><img style={styles} src={freeItem.photo} onClick={this.toggleViewPhoto.bind(this, freeItem.photo)} /></td>
                    <td>
                        <Button color="success" size="sm" className="mr-2" onClick={this.editFreeItem.bind(this, freeItem.id, freeItem.name, freeItem.description)}> Edit</Button>
                        <Button color="danger" size="sm" onClick={this.deleteFreeItem.bind(this, freeItem.id)}> Delete</Button>
                    </td>
                </tr>);
        });

        return (
            <div className="App container">

                <div>
                    <Button color="primary" onClick={this.toggleNewFreeItemModal.bind(this)} className="my-3">Add Free Item</Button>

                    <FreeItemNavbar></FreeItemNavbar>
                </div>

                {/*TABLE*/}
                <div>
                    <Table>
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Description</th>
                                <th>Photo</th>
                                <th>Actions</th>
                            </tr>
                        </thead>

                        <tbody>
                            {freeItems}
                        </tbody>
                    </Table>
                </div>


                {/*MODALS*/}
                <div>
                    <NewFreeItemModal appComponent={appComponent}></NewFreeItemModal>
                    <EditFreeItemModal appComponent={appComponent}></EditFreeItemModal>
                    <ViewPhotoModal appComponent={appComponent}></ViewPhotoModal>
                </div>

            </div>

        );
    }
}