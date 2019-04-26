import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label, FormGroup } from 'reactstrap';

export default class NewFreeItemModal extends Component {

    render() {

        const appComponent = this.props.appComponent;

        return (
            <Modal isOpen={appComponent.state.newFreeItemModal} toggle={appComponent.toggleNewFreeItemModal.bind(appComponent)}>

                <ModalHeader toggle={appComponent.toggleNewFreeItemModal.bind(appComponent)}>Add a new Free Item</ModalHeader>

                <ModalBody>

                    <FormGroup>
                        <Label for="name">Name</Label>
                        <Input id="name" value={appComponent.state.newFreeItemData.name} onChange={(e) => {
                            let { newFreeItemData } = appComponent.state;

                            newFreeItemData.name = e.target.value;

                            appComponent.setState({ newFreeItemData });
                        }} />
                    </FormGroup>

                    <FormGroup>
                        <Label for="description">Description</Label>
                        <Input id="description" value={appComponent.state.newFreeItemData.description} onChange={(e) => {
                            let { newFreeItemData } = appComponent.state;

                            newFreeItemData.description = e.target.value;

                            appComponent.setState({ newFreeItemData });
                        }} />
                    </FormGroup>

                    <input type="file" value='' onChange={(e) => {
                        let { newFreeItemData } = appComponent.state;
                        let reader = new FileReader();

                        reader.readAsDataURL(e.target.files[0]);

                        reader.onloadend = () => {
                            newFreeItemData.photo = reader.result;

                            appComponent.setState({ newFreeItemData });
                        }
                    }} />

                </ModalBody>

                <ModalFooter>
                    <Button color="primary" onClick={appComponent.addFreeItem.bind(appComponent)}>Add Free Item</Button>{' '}
                    <Button color="secondary" onClick={appComponent.toggleNewFreeItemModal.bind(appComponent)}>Cancel</Button>
                </ModalFooter>

            </Modal>
        )
    }
}        