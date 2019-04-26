import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label, FormGroup } from 'reactstrap';

export default class EditFreeItemModal extends Component {
    render() {

        const appComponent = this.props.appComponent;

        return (
            <Modal isOpen={appComponent.state.editFreeItemModal} toggle={appComponent.toggleEditFreeItemModal.bind(appComponent)}>
                <ModalHeader toggle={appComponent.toggleEditFreeItemModal.bind(appComponent)}>Update a free Item</ModalHeader>
                <ModalBody>

                    <FormGroup>
                        <Label for="name">Name</Label>
                        <Input id="name" value={appComponent.state.editFreeItemData.name} onChange={(e) => {
                            let { editFreeItemData } = appComponent.state;

                            editFreeItemData.name = e.target.value;

                            appComponent.setState({ editFreeItemData });
                        }} />
                    </FormGroup>

                    <FormGroup>
                        <Label for="description">Description</Label>
                        <Input id="description" value={appComponent.state.editFreeItemData.description} onChange={(e) => {
                            let { editFreeItemData } = appComponent.state;

                            editFreeItemData.description = e.target.value;

                            appComponent.setState({ editFreeItemData });
                        }} />
                    </FormGroup>

                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={appComponent.updateFreeItem.bind(appComponent)}>Update Free Item</Button>{' '}
                    <Button color="secondary" onClick={appComponent.toggleEditFreeItemModal.bind(appComponent)}>Cancel</Button>
                </ModalFooter>
            </Modal>
        )
    }
}